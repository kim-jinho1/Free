using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStartState : BattleState
{
    public BattleStartState(Battle battle, BattleStateMachine stateMachine, string animBoolHash) : base(battle, stateMachine, animBoolHash)
    {
        
    }

    private bool FirstAttack(int a, int b)
    {
        return a > b ? true : false;
    }

    public void Exit()
    {
        StateMachine.ChangeState(BattleStateEnum.MiddleState);
    }
}
