using System;

using System.Collections.Generic;
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

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private List<MapGroup> _maps = new();
   
    private int _mapScale = 50;
    
    public Dictionary<int,MapType> _map = new();

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
        
    }

    private void CreateMap()
    {
        int scale = 0;
        int floor = 1;

        while (scale < _mapScale)
        {
            int random = UnityEngine.Random.Range(0, 11);

            if (floor % 10 == 0) 
            {
                _map.Add(floor,MapType.BossMap);
                floor++;
                scale++;
            }
            else if (random >= 9)
            {
                _map.Add(floor,MapType.EventMap);
                floor++;
                scale++;
            }
            else
            {
                _map.Add(floor,MapType.NormalMap);
                floor++;
                scale++;
            }
        }
    }
}
