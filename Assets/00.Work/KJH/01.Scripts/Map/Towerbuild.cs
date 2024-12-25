using System;
using UnityEngine;

public class Towerbuild : MonoSingleton<Towerbuild>
{
    [SerializeField] private GameObject[] _normalFloors;
    [SerializeField] private GameObject[] _eventFloors;
    [SerializeField] private GameObject[] _middleBosFloors;
    [SerializeField] private GameObject[] _finalBossFloors;

    private GameObject _map;

    public void Tower(int a, MapType mapType)
    {
        _map = null;

        GameObject gm = mapType switch
        {
            MapType.NormalMap => Instantiate(BuildNormalFloor(a), MapManager.Instance._mapPool.transform),
            MapType.EventMap => Instantiate(BuildEventFloor(), MapManager.Instance._mapPool.transform),
            MapType.MiddleBossMap => Instantiate(BuildMiddleBossFloor(), MapManager.Instance._mapPool.transform),
            MapType.FinalBossMap => Instantiate(BuildFinalBossFloor(), MapManager.Instance._mapPool.transform),
            _ => throw new ArgumentOutOfRangeException()
        };

        // 적 생성 및 설정
        GameObject enemy = gm.GetComponent<Map>().CreateEnemy();  // CreateEnemy 메서드 호출
        if (gm.transform.GetChild(UnityEngine.Random.Range(0,4)).TryGetComponent(out IMap iMap))
        {
            iMap.SettingRoom(a, enemy);  // 적을 SettingRoom에 전달
        }

        _map = gm;
        gm.SetActive(false);
        MapManager.Instance.tower.Add(gm);
    }


    public GameObject BuildEventFloor()
    {
        int rand = UnityEngine.Random.Range(0, _eventFloors.Length);
        return _eventFloors[rand];
    }

    public GameObject BuildNormalFloor(int a)
    {

        int rand = UnityEngine.Random.Range(0, _normalFloors.Length);
        return _normalFloors[rand];
    }

    public GameObject BuildFinalBossFloor()
    {
        int rand = UnityEngine.Random.Range(0, _finalBossFloors.Length);
        return _finalBossFloors[rand];
    }

    public GameObject BuildMiddleBossFloor()
    {
        int rand = UnityEngine.Random.Range(0, _middleBosFloors.Length);
        return _middleBosFloors[rand];
    }
}