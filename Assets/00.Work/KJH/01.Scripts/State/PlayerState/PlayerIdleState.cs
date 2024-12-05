using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string animBoolHash) : base(player, stateMachine, animBoolHash)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        HorizontalRoom.OnClick += CheckHorizontalRoom;
        VerticalRoom.OnClick += CheckVerticalRoom;
    }

    private void CheckVerticalRoom()
    {
        if (Player.IsCenter)
        {
            StateMachine.ChangeState(PlayerStateEnum.UI);
        }
        else if (!Player.IsCenter) 
        {
            StateMachine.ChangeState(PlayerStateEnum.HorizontalMove);
        }
        StateMachine.ChangeState(PlayerStateEnum.HorizontalMove);
    }
    
    private void CheckHorizontalRoom()
    {
        StateMachine.ChangeState(PlayerStateEnum.HorizontalMove);
    }
    
    private void CheckRoom(Collider2D hitCollider)
    {
        if (hitCollider != null)
        {
            if (hitCollider.GetComponent<VerticalRoom>() != null)
            {
                Player.Collider = null;
                if (Player.IsCenter)
                {
                    StateMachine.ChangeState(PlayerStateEnum.VerticalMove);
                    Player.OnMoveVertical?.Invoke(hitCollider.transform);
                }
                else if (!Player.IsCenter) 
                {
                    StateMachine.ChangeState(PlayerStateEnum.HorizontalMove);
                    Player.OnMoveHorizontal?.Invoke(hitCollider.transform); 
                }
            }
            else if (hitCollider.GetComponent<HorizontalRoom>() != null)
            {
                Player.Collider = null;
                StateMachine.ChangeState(PlayerStateEnum.HorizontalMove);
                Player.OnMoveHorizontal?.Invoke(hitCollider.transform);
            }
        }
    }
    public override void Update()
    {
        if (Player.Collider != null)
        {
            
        }
    }

    public override void Exit()
    {
        base.Exit();
        HorizontalRoom.OnClick -= CheckHorizontalRoom;
        VerticalRoom.OnClick -= CheckVerticalRoom;
    }
}
