using System.Collections.Generic;
using PurrNet.Logging;

namespace PurrNet.Modules
{
    internal struct ClientFinishedLoadingScene
    {
        public SceneID scene;
    }
    
    public delegate void OnPlayerSceneEvent(PlayerID player, SceneID scene, bool asserver);

    public class ScenePlayersModule : INetworkModule
    {
        private readonly Dictionary<SceneID, HashSet<PlayerID>> _scenePlayers = new();
        private readonly Dictionary<SceneID, HashSet<PlayerID>> _sceneLoadedPlayers = new();
        
        readonly ScenesModule _scenes;
        readonly PlayersManager _players;
        
        /// <summary>
        /// Called once the player has started joining the scene (before loading)
        /// </summary>
        public event OnPlayerSceneEvent onPlayerJoinedScene;
        
        /// <summary>
        /// Called once the player has finished loading the scene
        /// </summary>
        public event OnPlayerSceneEvent onPrePlayerloadedScene;
        
        /// <summary>
        /// Called once the player has finished loading the scene
        /// </summary>
        public event OnPlayerSceneEvent onPlayerLoadedScene;
        
        /// <summary>
        /// Called once the player has finished loading the scene
        /// </summary>
        public event OnPlayerSceneEvent onPostPlayerLoadedScene;
        
        public event OnPlayerSceneEvent onPlayerLeftScene;
        public event OnPlayerSceneEvent onPlayerUnloadedScene;
        
        private bool _asServer;
        
        private readonly NetworkManager _manager;
        
        public ScenePlayersModule(NetworkManager manager, ScenesModule scenes, PlayersManager players)
        {
            _manager = manager;
            _scenes = scenes;
            _players = players;
        }
        
        public void Enable(bool asServer)
        {
            _asServer = asServer;
            
            if (asServer)
            {
                for (var i = 0; i < _scenes.scenes.Count; i++)
                {
                    var scene = _scenes.scenes[i];
                    OnSceneLoaded(scene, _asServer);
                }
                
                _scenes.onSceneLoaded += OnSceneLoaded;
                _scenes.onSceneUnloaded += OnSceneUnloaded;
                _scenes.onSceneVisibilityChanged += OnSceneVisibilityChanged;
                _players.onPrePlayerJoined += OnPlayerJoined;
                _players.onPlayerLeft += OnPlayerLeft;

                _players.Subscribe<ClientFinishedLoadingScene>(RemoteClientLoadedScene);
            }
            else
            {
                if (_players.localPlayerId.HasValue)
                     OnLocalPlayerReady(_players.localPlayerId.Value);
                else _players.onLocalPlayerReceivedID += OnLocalPlayerReady;

                _scenes.onSceneLoaded += OnClientSceneLoaded;
            }
        }

        private void OnLocalPlayerReady(PlayerID player)
        {
            for (var i = 0; i < _scenes.scenes.Count; i++)
            {
                OnClientSceneLoaded(_scenes.scenes[i], _asServer);
            }
            
            _players.onLocalPlayerReceivedID -= OnLocalPlayerReady;
        }

        public void Disable(bool asServer)
        {
            if (asServer)
            {
                _scenes.onSceneLoaded -= OnSceneLoaded;
                _scenes.onSceneUnloaded -= OnSceneUnloaded;
                _scenes.onSceneVisibilityChanged -= OnSceneVisibilityChanged;
                _players.onPrePlayerJoined -= OnPlayerJoined;
                _players.onPlayerLeft -= OnPlayerLeft;
                
                _players.Unsubscribe<ClientFinishedLoadingScene>(RemoteClientLoadedScene);
            }
            else
            {
                _players.onLocalPlayerReceivedID -= OnLocalPlayerReady;
                _scenes.onSceneUnloaded -= OnClientSceneLoaded;
            }
        }

        private void OnPlayerLeft(PlayerID player, bool asserver)
        {
            if (!_manager.networkRules.ShouldRemovePlayerFromSceneOnLeave())
            {
                foreach (var (scene, players) in _sceneLoadedPlayers)
                {
                    if (players.Remove(player))
                        onPlayerUnloadedScene?.Invoke(player, scene, _asServer);
                }
                return;
            }
            
            foreach (var (scene, players) in _scenePlayers)
            {
                if (!players.Contains(player))
                    continue;

                RemovePlayerFromScene(player, scene);
            }
        }

        private void OnClientSceneLoaded(SceneID scene, bool asserver)
        {
            if (!_players.localPlayerId.HasValue)
            {
                PurrLogger.LogError("Local player ID not set; aborting OnClientSceneLoaded");
                return;
            }
            
            onPrePlayerloadedScene?.Invoke(_players.localPlayerId.Value, scene, asserver);
            onPlayerLoadedScene?.Invoke(_players.localPlayerId.Value, scene, asserver);
            onPostPlayerLoadedScene?.Invoke(_players.localPlayerId.Value, scene, asserver);
            
            _players.SendToServer(new ClientFinishedLoadingScene { scene = scene });
        }
        
        private void RemoteClientLoadedScene(PlayerID player, ClientFinishedLoadingScene data, bool asserver)
        {
            if (!_scenePlayers.TryGetValue(data.scene, out var playersInScene))
                return;
            
            if (!playersInScene.Contains(player))
                return;
            
            if (_sceneLoadedPlayers.TryGetValue(data.scene, out var loadedPlayers))
            {
                loadedPlayers.Add(player);
            }
            else
            {
                PurrLogger.LogError($"SceneID '{data.scene}' not found in scene loaded players dictionary");
            }
            
            onPrePlayerloadedScene?.Invoke(player, data.scene, asserver);
            onPlayerLoadedScene?.Invoke(player, data.scene, asserver);
            onPostPlayerLoadedScene?.Invoke(player, data.scene, asserver);
        }

        /// <summary>
        /// Get all players that are both part of the scene and have finished loading the scene
        /// </summary>
        public bool TryGetPlayersInScene(SceneID scene, out HashSet<PlayerID> players)
        {
            if (_sceneLoadedPlayers.TryGetValue(scene, out var data))
            {
                players = data;
                return true;
            }
            
            players = null;
            return false;
        }
        
        /// <summary>
        /// Get all players attached to a scene, regardless of whether they have finished loading the scene or not
        /// </summary>
        public bool TryGetPlayersAttachedToScene(SceneID scene, out ISet<PlayerID> players)
        {
            if (_scenePlayers.TryGetValue(scene, out var data))
            {
                players = data;
                return true;
            }
            
            players = null;
            return false;
        }

        private void OnSceneVisibilityChanged(SceneID scene, bool isPublic, bool asServer)
        {
            if (!isPublic) return;
            
            if (!_scenePlayers.TryGetValue(scene, out var playersInScene))
                return;
            
            // if the scene is public, add all connected players to the scene
            int connectedPlayersCount = _players.players.Count;

            for (int i = 0; i < connectedPlayersCount; i++)
            {
                var player = _players.players[i];
                playersInScene.Add(player);

                onPlayerJoinedScene?.Invoke(player, scene, asServer);
            }
        }

        private void OnPlayerJoined(PlayerID player, bool isReconnect, bool asserver)
        {
            if (isReconnect && !_manager.networkRules.ShouldRemovePlayerFromSceneOnLeave())
            {
                /*foreach (var (scene, players) in _scenePlayers)
                {
                    if (players.Contains(player))
                        continue;
                    
                    AddPlayerToScene
                }*/
                return;
            }
            
            for (var i = 0; i < _scenes.scenes.Count; i++)
            {
                var scene = _scenes.scenes[i];
                
                if (!_scenes.TryGetSceneState(scene, out var state))
                    continue;

                if (!state.settings.isPublic)
                    continue;

                AddPlayerToScene(player, scene);
            }
        }

        public bool IsPlayerInScene(PlayerID player, SceneID scene)
        {
            return _scenePlayers.TryGetValue(scene, out var playersInScene) && playersInScene.Contains(player);
        }
        
        public IEnumerator<SceneID> GetPlayerScenes(PlayerID player)
        {
            foreach (var (scene, players) in _scenePlayers)
            {
                if (players.Contains(player))
                    yield return scene;
            }
        }

        /// <summary>
        /// Remove the player from all scenes and add them to the new scene
        /// </summary>
        public void MovePlayerToSingleScene(PlayerID player, SceneID scene)
        {
            foreach (var (existingScene, players) in _scenePlayers)
            {
                if (!players.Contains(player))
                    continue;
                
                RemovePlayerFromScene(player, existingScene);
            }
            
            AddPlayerToScene(player, scene);
        }

        public void AddPlayerToScene(PlayerID player, SceneID scene)
        {
            if (!_asServer)
            {
                PurrLogger.LogError("AddPlayerToScene can only be called on the server; for now ;)");
                return;
            }

            if (!_scenePlayers.TryGetValue(scene, out var playersInScene))
            {
                PurrLogger.LogError($"SceneID '{scene}' not found in scenes module; aborting AddPlayerToScene");
                return;
            }

            if (playersInScene.Add(player))
                onPlayerJoinedScene?.Invoke(player, scene, _asServer);
        }
        
        public void RemovePlayerFromScene(PlayerID player, SceneID scene)
        {
            if (!_asServer)
            {
                PurrLogger.LogError("RemovePlayerFromScene can only be called on the server; for now ;)");
                return;
            }
            
            RemovePlayerFromLoadedScene(player, scene);
            
            if (!_scenePlayers.TryGetValue(scene, out var playersInScene))
            {
                PurrLogger.LogError($"SceneID '{scene}' not found in scenes module; aborting RemovePlayerFromScene");
                return;
            }
            
            if (playersInScene.Remove(player))
                onPlayerLeftScene?.Invoke(player, scene, _asServer);
        }
        
        private void RemovePlayerFromLoadedScene(PlayerID player, SceneID scene)
        {
            if (!_sceneLoadedPlayers.TryGetValue(scene, out var playersInScene))
            {
                PurrLogger.LogError($"SceneID '{scene}' not found in scene loaded players dictionary; aborting RemovePlayerFromLoadedScene");
                return;
            }
            
            if (playersInScene.Remove(player))
                onPlayerUnloadedScene?.Invoke(player, scene, _asServer);
        }

        private void OnSceneLoaded(SceneID scene, bool asServer)
        {
            if (!_scenes.TryGetSceneState(scene, out var state))
            {
                PurrLogger.LogError($"SceneID '{scene}' not found in scenes module");
                return;
            }

            _scenePlayers.Add(scene, new HashSet<PlayerID>());
            _sceneLoadedPlayers.Add(scene, new HashSet<PlayerID>());
            
            OnSceneVisibilityChanged(scene, state.settings.isPublic, asServer);
        }
        
        private void OnSceneUnloaded(SceneID scene, bool asServer)
        {
            if (_scenePlayers.TryGetValue(scene, out var playersInScene))
            {
                // remove all players from the scene
                foreach (var player in playersInScene)
                {
                    onPlayerLeftScene?.Invoke(player, scene, asServer);
                    onPlayerUnloadedScene?.Invoke(player, scene, asServer);
                }
                
                _scenePlayers.Remove(scene);
                _sceneLoadedPlayers.Remove(scene);
            }
        }
    }
}
