using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] public GameObject _mapPool;
    [SerializeField] public GameObject _enemyPool;
    [SerializeField] public GameObject _battlePanel;

    [SerializeField] private Player _player;

    private int _mapScale = 50;

    public int _currentFloor;

    public List<GameObject> tower = new();

    private void Awake()
    {
        CreateMap();
    }

    private void Start()
    {
        _currentFloor = 1;
        tower[_currentFloor].SetActive(true);
    }

    private void CreateMap()
    {
        int scale = 0;
        int floor = 1;

        while (scale <= _mapScale)
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
         Towerbuild.Instance.Tower(floor, mapType);
    }

    public void ChangeFloor(bool isChange)
    {
        if (tower[_currentFloor] is not null)
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
    }
}
