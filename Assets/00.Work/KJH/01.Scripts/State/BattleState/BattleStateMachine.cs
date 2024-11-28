using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleStateEnum
{
    MiddleState,
    StartState,
    EndState,
    NotState
}

public class BattleStateMachine
{
    public BattleState currentState;

    public Dictionary<BattleStateEnum, BattleState> BattleStates = new();

    public void Initialize(BattleStateEnum state)
    {
        currentState = BattleStates[state];
        currentState.Enter();
    }

    public void AddState(BattleStateEnum stateEnum, BattleState state)
    {
        BattleStates.Add(stateEnum, state);
    }

    public void ChangeState(BattleStateEnum stateEnum)
    {
        currentState.Exit();
        currentState = BattleStates[stateEnum];
        currentState.Enter();
    }
}
