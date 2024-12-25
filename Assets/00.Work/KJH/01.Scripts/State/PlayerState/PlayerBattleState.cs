using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleState : PlayerState
{
    public PlayerBattleState(Player player, PlayerStateMachine stateMachine, string animBoolHash) : base(player, stateMachine, animBoolHash)
    {

    }

    public override void Enter()
    {
        base.Enter();
        Player._battle.StateMachine.ChangeState(BattleStateEnum.StartState);

    }



    public override void Exit()
    {
        base.Exit();
    }
}
