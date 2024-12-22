using UnityEngine;

public class Towerbuild : MonoSingleton<Towerbuild>
{
    [SerializeField] private GameObject[] _normalFloors; 
    [SerializeField] private GameObject[] _eventFloors;
    [SerializeField] private GameObject[] _middleBosFloors;
    [SerializeField] private GameObject[] _finalBossFloors;

    private GameObject _map;

    public void Tower(int a , MapType mapType)
    {
        _map = null;
        GameObject gm = Instantiate(BuildNormalFloor(a), MapManager.Instance._mapPool.transform);

        if (gm.transform.GetChild(3).TryGetComponent(out IMap iMap))
        {
            iMap.SettingRoom(a,gm.GetComponent<Map>().CreateEnemy());
        }
        _map = gm;
        gm.SetActive(false);
        MapManager.Instance.tower.Add(gm);
    }

    public GameObject BuildEventFloor()
    {
        int rand = Random.Range(0, _eventFloors.Length);
        return _eventFloors[rand];
    }
    
    public GameObject BuildNormalFloor(int a)
    {
        
        int rand = Random.Range(0, _normalFloors.Length);
        return _normalFloors[rand];
    }
    
    public GameObject BuildFinalBossFloor()
    {
        int rand = Random.Range(0, _finalBossFloors.Length);
        return _finalBossFloors[rand];
    }
    
    public GameObject BuildMiddleBossFloor()
    {
        int rand = Random.Range(0, _middleBosFloors.Length);
        return _middleBosFloors[rand];
    }
}
