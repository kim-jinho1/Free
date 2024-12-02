using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private TextMeshProUGUI currentFloorText;
    [SerializeField] public GameObject mapPanel;
    
    [SerializeField] private List<MapGroup> _maps = new();

    private int _mapScale = 50;

    private Dictionary<int, MapType> _map = new();    // 층 데이터 매핑
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

            if (floor % 10 == 0)
            {
                _map.Add(floor, MapType.BossMap);
            }
            else if (random >= 9)
            {
                _map.Add(floor, MapType.EventMap);
            }
            else
            {
                _map.Add(floor, MapType.NormalMap);
            }
            floor++;
            scale++;
        }
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
        {
            Destroy(child.gameObject);
        }
        
        var mapType = _map[floor];
        GameObject floorUI = Instantiate(floorPrefab, contentParent);
        //floorUI.GetComponentInChildren<TextMeshProUGUI>().text = $"Floor {floor}\nType: {mapType}";
        
        currentFloorText.text = $"Current Floor: {floor}";
    }
}
