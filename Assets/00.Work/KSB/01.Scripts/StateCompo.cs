using UnityEngine;

public class StateCompo : MonoBehaviour
{
    [SerializeField] private Enemy_State Idle, Attack,Hit,Death;

    public Enemy_State GetState(StateType type)
    => type switch
    {
        StateType.Idle
        => Idle,
        StateType.Attack
        => Attack,
        StateType.Hit
        => Hit,
        StateType.Death
       => Death

    };

}

public enum StateType
{
    Idle,
    Attack,
    Hit,
    Death
        
  
}

