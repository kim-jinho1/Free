using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    NormalMap
}

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private List<MapGroup> _maps = new();
   
    private int _mapScale = 50;
    
    public Dictionary<int,MapType> _map = new();

    private void Awake()
    {
        for (int i = 1; i <= _mapScale; i++)    
        {
            if (i % 10 == 0)
            {
                _map.Add(i,MapType.BossMap);
            }
            else
            {
                _map.Add(i,MapType.NormalMap);
            }
        }
        
        _maps.Clear();
        foreach (var entry in _map)
        {
            _maps.Add(new MapGroup { floor = entry.Key, mapType = entry.Value });
        }
    }

    private void Start()
    {
        
    }
}
