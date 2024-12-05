using System.Collections.Generic;
using PurrNet.Logging;
using PurrNet.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PurrNet.Modules
{
    internal struct PendingOperation
    {
        public int buildIndex;
        public SceneID idToAssign;
        public PurrSceneSettings settings;
    }

    internal struct SceneState
    {
        public Scene scene;
        public PurrSceneSettings settings;

        public SceneState(Scene scene, PurrSceneSettings settings)
        {
            this.scene = scene;
            this.settings = settings;
        }
    }

    public struct PurrSceneSettings
    {
        public LoadSceneMode mode;
        public LocalPhysicsMode physicsMode;
        public bool isPublic;
        internal bool wasPresentFromStart;
    }
    
    public delegate void OnSceneActionEvent(SceneID scene, bool asServer);
    public delegate void OnSceneVisibilityEvent(SceneID scene, bool isVisible, bool asServer);
    
    public class ScenesModule : INetworkModule, IFixedUpdate, ICleanup
    {
        private readonly NetworkManager _networkManager;
        private readonly PlayersManager _players;
        
        private readonly SceneHistory _history;
        private bool _asServer;
        
        private readonly List<PendingOperation> _pendingOperations = new ();
        private readonly Queue<SceneAction> _actionsQueue = new ();

        private readonly Dictionary<SceneID, SceneState> _scenes = new ();
        private readonly Dictionary<Scene, SceneID> _idToScene = new ();
        private readonly List<SceneID> _rawScenes = new ();
        
        /// <summary>
        /// First callback for when a scene is loaded
        /// </summary>
        public event OnSceneActionEvent onPreSceneLoaded;
        
        /// <summary>
        /// Callback for when a scene is loaded
        /// </summary>
        public event OnSceneActionEvent onSceneLoaded;
        
        /// <summary>
        /// Callback for after onSceneLoaded has been called
        /// </summary>
        public event OnSceneActionEvent onPostSceneLoaded;
        
        /// <summary>
        /// Callback for when a scene is unloaded
        /// </summary>
        public event OnSceneActionEvent onSceneUnloaded;
        
        /// <summary>
        /// Callback for when a scene's visibility changes
        /// </summary>
        public event OnSceneVisibilityEvent onSceneVisibilityChanged;

        private ushort _nextSceneID;
        private ScenePlayersModule _scenePlayers;
        
        public IReadOnlyList<SceneID> scenes => _rawScenes;
        
        private SceneID GetNextID() => new(_nextSceneID++);

        public ScenesModule(NetworkManager manager, PlayersManager players)
        {
            _networkManager = manager;
            _players = players;
            _history = new SceneHistory();
        }
        
        internal void SetScenePlayers(ScenePlayersModule scenePlayersModule)
        {
            _scenePlayers = scenePlayersModule;
        }
        
        internal bool TryGetSceneState(SceneID sceneID, out SceneState state)
        {
            return _scenes.TryGetValue(sceneID, out state);
        }
        
        private void AddScene(Scene scene, PurrSceneSettings settings, SceneID id)
        {
            _scenes.Add(id, new SceneState(scene, settings));
            _idToScene.Add(scene, id);
            _rawScenes.Add(id);
            
            onPreSceneLoaded?.Invoke(id, _asServer);
            onSceneLoaded?.Invoke(id, _asServer);
            onPostSceneLoaded?.Invoke(id, _asServer);
        }
        
        /// <summary>
        /// Used to modify whether the given scene is public or not
        /// </summary>
        /// <param name="scene">The SceneID of the scene to modify</param>
        /// <param name="isPublic">Whether the given scene should be public</param>
        public void UpdateSceneVisibility(SceneID scene, bool isPublic)
        {
            if (_asServer)
            {
                PurrLogger.LogError("Only clients can change scene visibility; for now at least ;)");
                return;
            }
            
            if (!_scenes.TryGetValue(scene, out var state))
            {
                PurrLogger.LogError($"Scene with ID {scene} not found");
                return;
            }

            state.settings.isPublic = isPublic;
            _scenes[scene] = state;
            
            onSceneVisibilityChanged?.Invoke(scene, isPublic, _asServer);
        }
        
        private readonly List<SceneID> _scenesToTriggerUnloadEvent = new();
        
        private void RemoveScene(Scene scene)
        {
            if (!_idToScene.TryGetValue(scene, out var id))
                return;
            
            _scenes.Remove(id);
            _idToScene.Remove(scene);
            _rawScenes.Remove(id);
            _scenesToTriggerUnloadEvent.Add(id);
        }

        public void Enable(bool asServer)
        {
            _asServer = asServer;

            var currentScene = _networkManager.gameObject.scene;
            var originalScene = _networkManager.originalScene;
            
            AddScene(currentScene, new PurrSceneSettings
            {
                mode = LoadSceneMode.Single,
                isPublic = true,
                physicsMode = LocalPhysicsMode.None,
                wasPresentFromStart = true
            }, GetNextID());

            if (currentScene != originalScene)
            {
                AddScene(originalScene, new PurrSceneSettings
                {
                    mode = LoadSceneMode.Additive,
                    isPublic = true,
                    physicsMode = LocalPhysicsMode.None,
                    wasPresentFromStart = true
                }, GetNextID());
            }
            
            if (!asServer)
            {
                _players.Subscribe<SceneActionsBatch>(OnSceneActionsBatch);
            }
            else
            {
                _players.onPlayerJoined += OnPlayerJoined;
                _scenePlayers.onPlayerJoinedScene += OnPlayerJoinedScene;
                _scenePlayers.onPlayerLeftScene += OnPlayerLeftScene;
            }
            
            SceneManager.sceneLoaded += SceneManagerOnSceneLoaded;
        }
        
        public void Disable(bool asServer)
        {
            if (!asServer)
            {
                _players.Unsubscribe<SceneActionsBatch>(OnSceneActionsBatch);
            }
            else
            {
                _players.onPlayerJoined -= OnPlayerJoined;
                _scenePlayers.onPlayerJoinedScene -= OnPlayerJoinedScene;
                _scenePlayers.onPlayerLeftScene -= OnPlayerLeftScene;
            }
            
            SceneManager.sceneLoaded -= SceneManagerOnSceneLoaded;

            DoCleanup();
        }

        private void OnPlayerJoined(PlayerID player, bool isReconnect, bool asserver)
        {
            if (!asserver)
                return;
            
            var history = _history.GetFullHistory();
            
            _playerFilteredActions.Clear();
            
            for (var i = 0; i < history.actions.Count; i++)
            {
                var action = history.actions[i];
                        
                var target = action.type switch
                {
                    SceneActionType.Load => action.loadSceneAction.sceneID,
                    SceneActionType.Unload => action.unloadSceneAction.sceneID,
                    SceneActionType.SetActive => action.setActiveSceneAction.sceneID,
                    _ => default
                };
                
                if (_scenePlayers.IsPlayerInScene(player, target))
                    _playerFilteredActions.Add(action);
            }

            if (_playerFilteredActions.Count > 0)
                _players.Send(player, new SceneActionsBatch { actions = _playerFilteredActions });
        }

        private void OnPlayerLeftScene(PlayerID player, SceneID scene, bool asserver)
        {
            if (!asserver)
                return;
            
            _playerFilteredActions.Clear();
            _playerFilteredActions.Add(new SceneAction
            {
                type = SceneActionType.Unload,
                unloadSceneAction = new UnloadSceneAction
                {
                    sceneID = scene,
                    options = UnloadSceneOptions.None
                }
            });

            _players.Send(player, new SceneActionsBatch { actions = _playerFilteredActions });
        }

        private void OnPlayerJoinedScene(PlayerID player, SceneID scene, bool asserver)
        {
            if (!asserver)
                return;
            
            var history = _history.GetFullHistory();
            
            _playerFilteredActions.Clear();
            
            // send all actions for the scene
            FilterActionsForPlayerBySceneID(player, scene, history.actions, _playerFilteredActions);

            if (_playerFilteredActions.Count > 0)
                _players.Send(player, new SceneActionsBatch { actions = _playerFilteredActions });
        }

        private void SceneManagerOnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            for (int i = 0; i < _pendingOperations.Count; i++)
            {
                var operation = _pendingOperations[i];

                if (operation.buildIndex == scene.buildIndex && operation.settings.mode == mode)
                {
                    AddScene(scene, operation.settings, operation.idToAssign);
                    _pendingOperations.RemoveAt(i);
                    break;
                }
            }
        }
        
        private bool IsScenePending(SceneID sceneId)
        {
            for (int i = 0; i < _pendingOperations.Count; i++)
            {
                if (_pendingOperations[i].idToAssign == sceneId)
                    return true;
            }
            
            return false;
        }

        private void HandleNextSceneAction()
        {
            if (_actionsQueue.Count == 0) return;
            
            var action = _actionsQueue.Peek();
            switch (action.type)
            {
                case SceneActionType.Load:
                {
                    if (_networkManager.isHost && !_asServer)
                    {
                        _actionsQueue.Dequeue();
                        break;
                    }
                    
                    var loadAction = action.loadSceneAction;

                    if (loadAction.buildIndex < 0 || loadAction.buildIndex >= SceneManager.sceneCountInBuildSettings)
                    {
                        PurrLogger.LogError($"Invalid build index {loadAction.buildIndex} to load");
                        break;
                    }
                    
                    SceneManager.LoadSceneAsync(loadAction.buildIndex, loadAction.GetLoadSceneParameters());

                    _pendingOperations.Add(new PendingOperation
                    {
                        buildIndex = loadAction.buildIndex,
                        settings = loadAction.parameters,
                        idToAssign = loadAction.sceneID
                    });
                    
                    _actionsQueue.Dequeue();
                    break;
                }
                case SceneActionType.Unload:
                {
                    var idx = action.unloadSceneAction.sceneID;
                    
                    if (_networkManager.isHost && !_asServer)
                    {
                        _scenesToTriggerUnloadEvent.Add(idx);
                        _actionsQueue.Dequeue();
                        break;
                    } 
                    
                    // if the scene is pending, don't do anything for now
                    if (IsScenePending(idx)) break;

                    if (!_scenes.TryGetValue(idx, out var sceneState))
                    {
                        PurrLogger.LogError($"Couldn't find scene with index {idx} to unload");
                        break;
                    }

                    SceneManager.UnloadSceneAsync(sceneState.scene, action.unloadSceneAction.options);
                    RemoveScene(sceneState.scene);
                    _actionsQueue.Dequeue();
                    break;
                }
            }
        }

        private void OnSceneActionsBatch(PlayerID player, SceneActionsBatch data, bool asserver)
        {
            for (var i = 0; i < data.actions.Count; i++)
                _actionsQueue.Enqueue(data.actions[i]);
            
            HandleNextSceneAction();
        }
        
        private static int SceneNameToBuildIndex(string name)
        {
            var bIdxCount = SceneManager.sceneCountInBuildSettings;
            
            for (int i = 0; i < bIdxCount; i++)
            {
                var path = SceneUtility.GetScenePathByBuildIndex(i);
                var sceneName = System.IO.Path.GetFileNameWithoutExtension(path);
                
                if (sceneName == name)
                {
                    return i;
                }
            }
            
            return -1;
        }
        
        /// <summary>
        /// Loads a scene asynchronously by its build index - Must be in build settings
        /// </summary>
        /// <param name="sceneIndex">Build index of the scene</param>
        /// <param name="mode">What UnityEngine scene load mode to use</param>
        public AsyncOperation LoadSceneAsync(int sceneIndex, LoadSceneMode mode = LoadSceneMode.Single)
        {
            var parameters = new LoadSceneParameters(mode);
            return LoadSceneAsync(sceneIndex, parameters);
        }

        /// <summary>
        /// Loads a scene asynchronously by its name - Must be in build settings
        /// </summary>
        /// <param name="sceneName">The name of the scene to load</param>
        /// <param name="mode">What UnityEngine scene load mode to use</param>
        public AsyncOperation LoadSceneAsync(string sceneName, LoadSceneMode mode = LoadSceneMode.Single)
        {
            var idx = SceneNameToBuildIndex(sceneName);
            
            if (idx == -1)
            {
                PurrLogger.LogError($"Scene {sceneName} not found in build settings");
                return null;
            }
            
            var parameters = new LoadSceneParameters(mode);
            return LoadSceneAsync(idx, parameters);
        }

        /// <summary>
        /// Loads a scene asynchronously by its name - Must be in build settings
        /// </summary>
        /// <param name="sceneName">The name of the scene to load</param>
        /// <param name="parameters">The UnityEngine LoadSceneParameters to use</param>
        public AsyncOperation LoadSceneAsync(string sceneName, LoadSceneParameters parameters)
        {
            var idx = SceneNameToBuildIndex(sceneName);
            
            if (idx == -1)
            {
                PurrLogger.LogError($"Scene {sceneName} not found in build settings");
                return null;
            }
            
            return LoadSceneAsync(idx, parameters);
        }
        
        /// <summary>
        /// Loads a scene asynchronously by its name - Must be in build settings
        /// </summary>
        /// <param name="sceneName">The name of the scene to load</param>
        /// <param name="settings">The PurrSceneSettings to use when loading the scene</param>
        public AsyncOperation LoadSceneAsync(string sceneName, PurrSceneSettings settings)
        {
            var idx = SceneNameToBuildIndex(sceneName);
            
            if (idx == -1)
            {
                PurrLogger.LogError($"Scene {sceneName} not found in build settings");
                return null;
            }
            
            return LoadSceneAsync(idx, settings);
        }

        /// <summary>
        /// Loads a scene asynchronously by its build index - Must be in build settings
        /// </summary>
        /// <param name="sceneIndex">Build index of the scene</param>
        /// <param name="parameters">The UnityEngine LoadSceneParameters to use</param>
        /// <returns></returns>
        public AsyncOperation LoadSceneAsync(int sceneIndex, LoadSceneParameters parameters)
        {
            if (!_asServer)
            {
                PurrLogger.LogError("Only server can load scenes; for now at least ;)");
                return null;
            }
            
            return LoadSceneAsync(sceneIndex, new PurrSceneSettings
            {
                mode = parameters.loadSceneMode,
                physicsMode = parameters.localPhysicsMode,
                isPublic = true
            });
        }

        public SceneID lastSceneId => new((ushort)(_nextSceneID - 1));

        /// <summary>
        /// Loads a scene asynchronously by its build index - Must be in build settings
        /// </summary>
        /// <param name="sceneIndex">Build index of the scene</param>
        /// <param name="settings">The PurrSceneSettings to use when loading the scene</param>
        /// <returns></returns>
        public AsyncOperation LoadSceneAsync(int sceneIndex, PurrSceneSettings settings)
        {
            if (!_asServer)
            {
                PurrLogger.LogError("Only server can load scenes; for now at least ;)");
                return null;
            }

            var idToAssign = GetNextID();
            var parameters = new LoadSceneParameters(settings.mode, settings.physicsMode);
            
            if (settings.mode == LoadSceneMode.Single)
            {
                if (TryGetSceneID(_networkManager.gameObject.scene, out var nmId) &&
                    TryGetSceneState(nmId, out var nmScene))
                {
                    if (nmScene.scene.name != "DontDestroyOnLoad")
                    {
                        PurrLogger.LogError("Network manager scene is not DontDestroyOnLoad and you are trying to" +
                                            " load a new scene with LoadSceneMode.Single");
                    }
                }
                
                // add unload action for every scene that is being loaded
                for (int i = 0; i < _rawScenes.Count; i++)
                {
                    bool isDontDestroyOnLoad = _scenes[_rawScenes[i]].scene.name == "DontDestroyOnLoad";
                    if (!isDontDestroyOnLoad)
                        _history.AddUnloadAction(new UnloadSceneAction { sceneID = _rawScenes[i], options = UnloadSceneOptions.None });
                }
            }

            _history.AddLoadAction(new LoadSceneAction
            {
                buildIndex = sceneIndex, 
                sceneID = idToAssign, 
                parameters = settings
            });
            
            var op = SceneManager.LoadSceneAsync(sceneIndex, parameters);
            var operation = new PendingOperation
            {
                buildIndex = sceneIndex,
                settings = settings,
                idToAssign = idToAssign
            };
            
            _pendingOperations.Add(operation);
            
            if (_asServer && _networkManager.isHost)
            {
                var clientModule = _networkManager.GetModule<ScenesModule>(false);
                clientModule._pendingOperations.Add(operation);
            }
            
            return op;
        }
        
        /// <summary>
        /// Unloads a scene asynchronously by its name - Must be in build settings
        /// </summary>
        /// <param name="sceneName">Name of the scene to unload</param>
        /// <param name="options">The UnityEngine UnloadSceneOptions to use for the unloading</param>
        public void UnloadSceneAsync(string sceneName, UnloadSceneOptions options = UnloadSceneOptions.None)
        {
            var scene = SceneManager.GetSceneByName(sceneName);
            
            if (!scene.IsValid())
            {
                PurrLogger.LogError($"Scene with name '{sceneName}' not found");
                return;
            }
            
            UnloadSceneAsync(scene, options);
        }

        /// <summary>
        /// Unloads a scene asynchronously by its build index - Must be in build settings
        /// </summary>
        /// <param name="buildIndex">Build index of the scene to unload</param>
        /// <param name="options">The UnityEngine UnloadSceneOptions to use for the unloading</param>
        public void UnloadSceneAsync(int buildIndex, UnloadSceneOptions options = UnloadSceneOptions.None)
        {
            var scene = SceneManager.GetSceneByBuildIndex(buildIndex);
            
            if (!scene.IsValid())
            {
                PurrLogger.LogError($"Scene with build index {buildIndex} not found");
                return;
            }
            
            UnloadSceneAsync(scene, options);
        }
        
        /// <summary>
        /// Unloads a scene asynchronously by its Scene object - Must be in build settings
        /// </summary>
        /// <param name="scene">The Scene to unload</param>
        /// <param name="options">The UnityEngine UnloadSceneOptions to use for the unloading</param>
        public void UnloadSceneAsync(Scene scene, UnloadSceneOptions options = UnloadSceneOptions.None)
        {
            if (!_asServer)
            {
                PurrLogger.LogError("Only server can unload scenes; for now at least ;)");
                return;
            }
            
            if (_networkManager.gameObject.scene == scene)
            {
                PurrLogger.LogError("Can't unload the network manager scene");
                return;
            }
            
            if (!_idToScene.TryGetValue(scene, out var sceneIndex))
            {
                PurrLogger.LogError($"Scene {scene.name} not found in scenes list");
                return;
            }
            
            _history.AddUnloadAction(new UnloadSceneAction { sceneID = sceneIndex, options = options});
            SceneManager.UnloadSceneAsync(scene, options);
            RemoveScene(scene);
        }
        
        static readonly List<SceneAction> _playerFilteredActions = new();

        private void FilterActionsForPlayer(PlayerID player, IReadOnlyList<SceneAction> actions, ICollection<SceneAction> destination)
        {
            for (var i = 0; i < actions.Count; i++)
            {
                var action = actions[i];
                        
                var target = action.type switch
                {
                    SceneActionType.Load => action.loadSceneAction.sceneID,
                    SceneActionType.Unload => action.unloadSceneAction.sceneID,
                    _ => default
                };

                if (_scenePlayers.IsPlayerInScene(player, target))
                    destination.Add(action);
            }
        }
        
        private void FilterActionsForPlayerBySceneID(PlayerID player, SceneID id, IReadOnlyList<SceneAction> actions, ICollection<SceneAction> destination)
        {
            for (var i = 0; i < actions.Count; i++)
            {
                var action = actions[i];
                        
                var target = action.type switch
                {
                    SceneActionType.Load => action.loadSceneAction.sceneID,
                    SceneActionType.Unload => action.unloadSceneAction.sceneID,
                    SceneActionType.SetActive => action.setActiveSceneAction.sceneID,
                    _ => default
                };
                
                if (target != id)
                    continue;

                if (_scenePlayers.IsPlayerInScene(player, target))
                    destination.Add(action);
            }
        }

        public void FixedUpdate()
        {
            HandleNextSceneAction();

            if (_history.hasUnflushedActions)
                FlushActions();

            if (_scenesToTriggerUnloadEvent.Count > 0)
            {
                for (var i = 0; i < _scenesToTriggerUnloadEvent.Count; i++)
                    onSceneUnloaded?.Invoke(_scenesToTriggerUnloadEvent[i], _asServer);
                _scenesToTriggerUnloadEvent.Clear();
            }
        }

        private void FlushActions()
        {
            var delta = _history.GetDelta();

            for (var i = 0; i < _players.players.Count; i++)
            {
                var player = _players.players[i];

                _playerFilteredActions.Clear();

                FilterActionsForPlayer(player, delta.actions, _playerFilteredActions);

                if (_playerFilteredActions.Count > 0)
                {
                    _players.Send(player, new SceneActionsBatch { actions = _playerFilteredActions });
                }
            }

            _history.Flush();
        }

        private void DoCleanup()
        {
            if (ApplicationContext.isQuitting) return;
            
            bool isAnythingConnected = _networkManager.isServer || _networkManager.isClient;
            
            if (isAnythingConnected) 
                return;

            foreach (var (id, scene) in _scenes)
            {
                if (id == default) 
                    continue;
                
                if (scene.settings.wasPresentFromStart)
                    continue;
                
                SceneManager.UnloadSceneAsync(scene.scene);
            }
        }

        private readonly List<AsyncOperation> _pendingUnloads = new();

        public bool Cleanup()
        {
            if (!_networkManager.isOffline)
                return true;

            if (_pendingOperations.Count > 0)
                return false;

            if (_scenes.Count > 0)
            {
                _pendingUnloads.Clear();

                foreach (var (id, scene) in _scenes)
                {
                    if (id == default)
                        continue;
                    
                    if (scene.settings.wasPresentFromStart)
                        continue;

                    _pendingUnloads.Add(SceneManager.UnloadSceneAsync(scene.scene));
                }

                _scenes.Clear();
            }
            
            if (_pendingUnloads.Count > 0)
            {
                for (int i = 0; i < _pendingUnloads.Count; i++)
                {
                    if (_pendingUnloads[i] != null && !_pendingUnloads[i].isDone)
                        return false;
                }
            } 

            return true;
        }

        /// <summary>
        /// Attempts to get the Networked SceneId of a scene
        /// </summary>
        /// <param name="scene">Scene to try and get</param>
        /// <param name="sceneId">Networked SceneID of the scene</param>
        /// <returns>Whether it successfully retrieved a scene or not</returns>
        public bool TryGetSceneID(Scene scene, out SceneID sceneId)
        {
            return _idToScene.TryGetValue(scene, out sceneId);
        }
        
        
        /// <summary>
        /// Attempts to get the Networked SceneId of a scene
        /// </summary>
        /// <param name="buildIndex">BuildIndex of Scene to try and get</param>
        /// <param name="sceneId">Networked SceneID of the scene</param>
        /// <returns>Whether it successfully retrieved a scene or not</returns>
        public bool TryGetScene(int buildIndex, out SceneID sceneId)
        {
            for (int i = 0; i < _rawScenes.Count; i++)
            {
                if (_scenes.TryGetValue(_rawScenes[i], out var state))
                {
                    if (state.scene.buildIndex == buildIndex)
                    {
                        sceneId = _rawScenes[i];
                        return true;
                    }
                }
            }

            sceneId = default;
            return false;
        }

        /// <summary>
        /// Checks whether a scene is loaded on the network
        /// </summary>
        /// <param name="buildIndex">Build index of scene to check</param>
        /// <returns>Whether the scene is loaded on the network or not</returns>
        public bool IsSceneLoaded(int buildIndex)
        {
            for (int i = 0; i < _rawScenes.Count; i++)
            {
                if (_scenes.TryGetValue(_rawScenes[i], out var state))
                {
                    if (state.scene.buildIndex == buildIndex)
                        return true;
                }
            }

            return false;
        }
    }
}
