using UnityEngine;

public class Towerbuild : MonoSingleton<Towerbuild>
{
    [SerializeField] private GameObject[] floors;
    
    public GameObject BuildEventFloor()
    {
        return floors[0];
    }
    
    public void BuildNormalFloor()
    {
        
    }
    
    public void BuildFinalBossFloor()
    {
        
    }
    
    public void BuildMiddleBossFloor()
    {
        
    }
}
