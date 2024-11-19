using UnityEngine;

public class StateCompo : MonoBehaviour
{
    [SerializeField] private Enemy_State Idle, Attack1, Attack2, Attack3;

    public Enemy_State GetState(StateType type)
    => type switch
    {
        StateType.Idle
        => Idle,
        StateType.Attack1
        => Attack1,
        StateType.Attack2
        => Attack2,
        StateType.Attack3
        => Attack3
    };

}

public enum StateType
{
    Idle,
    Attack1,
    Attack2,
    Attack3,
}

