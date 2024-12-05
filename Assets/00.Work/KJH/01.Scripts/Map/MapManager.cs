using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class MapGroup
{
    public int floor;
    public MapType mapType;
}

public enum MapType
{
    MiddleBossMap,
    NormalMap,
    EventMap,
    FinalBossMap
}

public class MapManager : MonoSingleton<MapManager>
{
    [Header("UI Elements")]
    [SerializeField] private Transform contentParent;
    [SerializeField] private GameObject pool;

    
    [SerializeField] private Player _player;
    
    [SerializeField] private List<MapGroup> _maps = new();

    private int _mapScale = 50;
    
    private Dictionary<int, MapType> _map = new();
    public int _currentFloor;

    public List<GameObject> tower = new List<GameObject>(); 
        
    private void Awake()
    {
        CreateMap();
        _maps.Clear();
        foreach (var entry in _map)
        {
            _maps.Add(new MapGroup { floor = entry.Key, mapType = entry.Value });
        }
    }

    private void Start()
    {
        _currentFloor = _player.CurrentFloor;
        tower[_currentFloor].SetActive(true);
    }
    
    private void CreateMap()
    {
        int scale = 0;
        int floor = 1;

        while (scale < _mapScale)
        {
            int random = UnityEngine.Random.Range(0, 11);
            if (floor == 50)
                MapBuild(floor, MapType.FinalBossMap);
            else if (floor % 10 == 0)
                MapBuild(floor, MapType.MiddleBossMap);
            else if (random >= 9)
                MapBuild(floor, MapType.EventMap);
            else
                MapBuild(floor, MapType.NormalMap);
            
            floor++;
            scale++;
        }
    }

    private void MapBuild(int floor, MapType mapType)
    {
        GameObject map = Instantiate(Towerbuild.Instance.BuildNormalFloor(), pool.transform);
        map.SetActive(false);
        tower.Add(map);
    }
    
    public  void MoveToFloor(int floor)
    {
        if (!_map.ContainsKey(floor))
        {
            Debug.LogWarning($"Floor {floor} does not exist.");
            return;
        }

        _currentFloor = floor;
        
        UpdateFloorUI(floor);
    }

    public void ChangeFloor(bool isChange)
    {
        if (isChange)
        {
            tower[_currentFloor].SetActive(false);
            _currentFloor++;
            tower[_currentFloor].SetActive(true);
            _player.CurrentFloor = _currentFloor;
        }
        else
        {
            tower[_currentFloor].SetActive(false);
            _currentFloor--;
            tower[_currentFloor].SetActive(true);
            _player.CurrentFloor = _currentFloor;
        }
    }
    private void UpdateFloorUI(int floor)
    {
        foreach (Transform child in contentParent)
            Destroy(child.gameObject);
    }
}
