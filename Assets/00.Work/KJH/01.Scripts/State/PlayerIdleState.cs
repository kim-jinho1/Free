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
    }

    public override void Exit()
    {
        base.Exit();
    }
}
