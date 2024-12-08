using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEndState : BattleState
{
    
    public BattleEndState(Battle battle, BattleStateMachine stateMachine, string animBoolHash) : base(battle, stateMachine, animBoolHash)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
    }

    public void GetReward()
    {

    }

    public void End()
    {
        battle.StateMachine.ChangeState(BattleStateEnum.NotState);
        _player.StateMachine.ChangeState(PlayerStateEnum.Idle);
    }
    public override void Exit()
    {
        base.Exit();
    }
}
