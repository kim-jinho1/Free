using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string animBoolHash) : base(player, stateMachine, animBoolHash)
    {
    }

    public override void Enter()
    {
        base.Enter();
        
    }

    private void CheckRoom()
    {
        Player.CheckRoom(Player.Collider);
    }
    public override void Update()
    {
        if (Player.MoveInput.sqrMagnitude > 0)
        {
            StateMachine.ChangeState(PlayerStateEnum.Move);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            StateMachine.ChangeState(PlayerStateEnum.Attack);
        }

        if (Player.Collider != null)
        {
            CheckRoom();
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
