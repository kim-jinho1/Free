using DG.Tweening;
using UnityEngine;

public class PlayerHorizontalMoveState : PlayerState
{
    private Transform _target;
    
    public PlayerHorizontalMoveState(Player player, PlayerStateMachine stateMachine, string animBoolHash) : base(player, stateMachine, animBoolHash)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        Player.OnMoveHorizontal += Move;
        HorizontalRoom.OnMove += Move;
        VerticalRoom.OnMove += Move;
    }
    private void Move(Transform target)
    {
        Player.Rigid.DOMoveX(target.position.x, 1f);
        _target = target;
        Debug.Log(_target);
    }

    public override void Exit()
    {
        base.Exit();
        Player.OnMoveHorizontal -= Move;
        HorizontalRoom.OnMove -= Move;
        VerticalRoom.OnMove -= Move;
    }

    public override void PlayerUpdate()
    { 
        if (_target != null)
        {
            if (Mathf.Approximately(_target.position.x, Player.transform.position.x) && !Mathf.Approximately(_target.position.x, Player.CenterPosition.position.x))
            {
                StateMachine.ChangeState(PlayerStateEnum.Idle);
                Player.IsCenter = false;
            }
            else if (Mathf.Approximately(_target.position.x, Player.transform.position.x) && Mathf.Approximately(_target.position.x, Player.CenterPosition.position.x))
            {
                StateMachine.ChangeState(PlayerStateEnum.Idle);
                Player.IsCenter = true;
            }
        }
        
    }
}