using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, string animBoolHash) : base(player, stateMachine, animBoolHash)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
    }
    
    

    private void ExitState()
    {
        StateMachine.ChangeState(PlayerStateEnum.Idle);
    }
    
    public override void Exit()
    {
        base.Exit();
    }

    public override void PlayerUpdate()
    {
        base.PlayerUpdate();
    }
}
