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
    BossMap,
    NormalMap,
    EventMap
}

public class MapManager : MonoSingleton<MapManager>
{
    [Header("UI Elements")]
    [SerializeField] private GameObject floorPrefab;
    [SerializeField] private Transform contentParent;
    [SerializeField] private GameObject pool;

    
    [SerializeField] private Player _player;
    
    [SerializeField] private List<MapGroup> _maps = new();

    private int _mapScale = 50;

    private Dictionary<int, MapType> _map = new();
    private int _currentFloor = 1;  
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
        MoveToFloor(1);
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
    private void UpdateFloorUI(int floor)
    {
        foreach (Transform child in contentParent)
            Destroy(child.gameObject);
    }
}
