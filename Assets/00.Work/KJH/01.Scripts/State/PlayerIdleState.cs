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
        CheckRoom(Player.Collider);
    }
    
    private void CheckRoom(Collider2D hitCollider)
    {
        if (hitCollider.GetComponent<VerticalRoom>() != null)
        {
            Player.Collider = null;
            if (Player.IsCenter)
            {
                StateMachine.ChangeState(PlayerStateEnum.VerticalMove);
                Player.OnMoveVertical?.Invoke(hitCollider.transform);
                Player.CurrentFloor = hitCollider.GetComponent<VerticalRoom>()._currentFloor;
                
            }
            else if (!Player.IsCenter &&
                     hitCollider.GetComponent<VerticalRoom>()._currentFloor == Player.CurrentFloor) 
            {
                StateMachine.ChangeState(PlayerStateEnum.HorizontalMove);
                Player.OnMoveHorizontal?.Invoke(hitCollider.transform); 
            }
        }
        else if (hitCollider.GetComponent<HorizontalRoom>() != null &&
                 hitCollider.GetComponent<HorizontalRoom>()._currentFloor == Player.CurrentFloor) 
        {
            Player.Collider = null;
            StateMachine.ChangeState(PlayerStateEnum.HorizontalMove);
            Player.OnMoveHorizontal?.Invoke(hitCollider.transform);
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
