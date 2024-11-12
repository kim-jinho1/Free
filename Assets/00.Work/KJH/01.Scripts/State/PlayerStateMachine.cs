using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerStateEnum
{
    Idle,
    Move,
    Attack
}

public class PlayerStateMachine
{
    public PlayerState currentState;

    public Dictionary<PlayerStateEnum, PlayerState> PlayerStates = new();

    public void Initialize(PlayerStateEnum state)
    {
        currentState = PlayerStates[state];
        currentState.Enter();
    }

    public void AddState(PlayerStateEnum stateEnum, PlayerState state)
    {
        PlayerStates.Add(stateEnum, state);
    }

    public void ChangeState(PlayerStateEnum stateEnum)
    {
        currentState.Exit();
        currentState = PlayerStates[stateEnum];
        currentState.Enter();
    }
}
