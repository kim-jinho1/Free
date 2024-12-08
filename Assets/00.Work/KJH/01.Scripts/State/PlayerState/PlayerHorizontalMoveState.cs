using DG.Tweening;
using UnityEngine;

public class PlayerHorizontalMoveState : PlayerState
{
    private bool _isMoveing = false;

    private Transform _target;
    
    public PlayerHorizontalMoveState(Player player, PlayerStateMachine stateMachine, string animBoolHash) : base(player, stateMachine, animBoolHash)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("enter state");
        RightRoom.OnRightMove += Move;
        LeftRoom.OnLeftMove += Move;
        CenterRoom.OnCenterMove += Move;
    }
    private void Move(Transform target)
    {
        if (!_isMoveing)
        {
            Player.Rigid.DOMoveX(target.position.x, 1f);
            _target = target;
            _isMoveing = true;
        }
    }

    public override void Exit()
    {
        base.Exit();
        RightRoom.OnRightMove -= Move;
        LeftRoom.OnLeftMove -= Move;
        CenterRoom.OnCenterMove -= Move;
    }


    public override void Update()
    {
        base.Update();

        if (_target != null)
        {
            if (Mathf.Approximately(_target.position.x, Player.transform.position.x) && !Mathf.Approximately(_target.position.x, Player.CenterPosition.position.x))
            {
                _isMoveing = false;
                StateMachine.ChangeState(PlayerStateEnum.Idle);
                Player.IsCenter = false;
            }
            else if (Mathf.Approximately(_target.position.x, Player.transform.position.x) && Mathf.Approximately(_target.position.x, Player.CenterPosition.position.x))
            {
                _isMoveing = false;
                StateMachine.ChangeState(PlayerStateEnum.Idle);
                Player.IsCenter = true;
            }
        }
    }
}