using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string animBoolHash) : base(player, stateMachine, animBoolHash)
    {

    }

    public override void Enter()
    {
        base.Enter();
        RightRoom.OnRightClick += CheckRoom;
        LeftRoom.OnLeftClick += CheckRoom;
        CenterRoom.OnCenterClick += CheckCenterRoom;
    }

    private void CheckRoom()
    {
        Debug.Log("enter state");
        StateMachine.ChangeState(PlayerStateEnum.HorizontalMove);
        Player.IsCenter = false;
    }

    private void CheckCenterRoom()
    {
        if (Player.IsCenter)
            StateMachine.ChangeState(PlayerStateEnum.UI);
        else if (!Player.IsCenter)
        {
            StateMachine.ChangeState(PlayerStateEnum.HorizontalMove);
            Player.IsCenter = true;
        }
    }

    public override void Exit()
    {
        base.Exit();
        RightRoom.OnRightClick -= CheckRoom;
        LeftRoom.OnLeftClick -= CheckRoom;
        CenterRoom.OnCenterClick -= CheckCenterRoom;
    }
}