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
        CheckRoom(Player.Collider);
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
                    MapManager.Instance.MoveToFloor(Player.CurrentFloor);
                    Player.CurrentFloor++;
                }
                else if (!Player.IsCenter) 
                {
                    StateMachine.ChangeState(PlayerStateEnum.HorizontalMove);
                    Player.OnMoveHorizontal?.Invoke(hitCollider.transform); 
                }
            }
        }
    }
    public override void Update()
    {
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
