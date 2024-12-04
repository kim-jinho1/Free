using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIState : PlayerState
{
    public PlayerUIState(Player player, PlayerStateMachine stateMachine, string animBoolHash) : base(player, stateMachine, animBoolHash)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        RoomPanel.OnClick += UIExit;
    }

    private void UIExit()
    {
        StateMachine.ChangeState(PlayerStateEnum.Idle);
    }
    
    public override void Exit()
    {
        base.Exit();
        RoomPanel.OnClick -= UIExit;
    }

    public override void PlayerUpdate()
    {
        base.PlayerUpdate();
    }
}
