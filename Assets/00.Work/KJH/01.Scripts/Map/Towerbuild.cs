using UnityEngine;

public class Towerbuild : MonoSingleton<Towerbuild>
{
    [SerializeField] private GameObject[] _normalFloors; 
    [SerializeField] private GameObject[] _eventFloors;
    [SerializeField] private GameObject[] _middleBosFloors;
    [SerializeField] private GameObject[] _finalBossFloors;
    
    public GameObject BuildEventFloor()
    {
        int rand = Random.Range(0, _eventFloors.Length);
        return _eventFloors[rand];
    }
    
    public GameObject BuildNormalFloor()
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
