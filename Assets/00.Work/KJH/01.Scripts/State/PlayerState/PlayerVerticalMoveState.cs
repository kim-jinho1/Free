using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerVerticalMoveState : PlayerState
{
    public PlayerVerticalMoveState(Player player, PlayerStateMachine stateMachine, string animBoolHash) : base(player, stateMachine, animBoolHash)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        Player.OnMoveVertical += Move;
    }


    private void Move(Transform target)
    {
        if (Player.IsCenter)
        {
            Player.Rigid.DOMoveY(target.position.y, 1f);
            Player.CenterPosition = target;
        }
    }
    public override void Exit()
    {
        base.Exit();
        Player.OnMoveVertical -= Move;
    }

    public override void Update()
    {
        base.Update();
        if (Mathf.Approximately(Player.CenterPosition.position.y, Player.transform.position.y))
        {
            StateMachine.ChangeState(PlayerStateEnum.Idle);
            Player.IsCenter = true;
        }
    }
}