using UnityEngine;
using UnityEngine.Serialization;

public class Towerbuild : MonoSingleton<Towerbuild>
{
    [SerializeField] private GameObject[] normalFloors; 
    [SerializeField] private GameObject[] eventFloors;
    
    public GameObject BuildEventFloor()
    {
        return eventFloors[0];
    }
    
    public GameObject BuildNormalFloor()
    {
        
        return normalFloors[0];
    }
    
    public void BuildFinalBossFloor()
    {
        
    }
    
    public void BuildMiddleBossFloor()
    {
        
    }
}
