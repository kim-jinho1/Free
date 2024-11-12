using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, string animBoolHash) : base(player, stateMachine, animBoolHash)
    {

    }

    public override void Update()
    {
        base.Update();
        SetVelocity();
        if (Player.MoveInput.sqrMagnitude <= 0) 
        {
            StateMachine.ChangeState(PlayerStateEnum.Idle);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            StateMachine.ChangeState(PlayerStateEnum.Attack);
        }

        Player.FiIpController();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public void MoveHorizontal()
    {
        
    }

    public void MoveVertical()
    {
        
    }

    public void SetVelocity()
    {

        Player.Rigid.velocity = new Vector2(Player.MoveInput.x * 5, 0);
    }

    private void StopVelocity()
    {
        Player.Rigid.velocity = Vector2.zero;
    }
}
