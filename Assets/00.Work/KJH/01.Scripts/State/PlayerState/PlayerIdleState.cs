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
            Player._panel.SetActive(true);
            StateMachine.ChangeState(PlayerStateEnum.UI);
        }
        else if (!Player.IsCenter)
        {
            StateMachine.ChangeState(PlayerStateEnum.HorizontalMove);
            Player.IsCenter = true;
        }
    }
    
    private void CheckHorizontalRoom()
    {
        StateMachine.ChangeState(PlayerStateEnum.HorizontalMove);
        Player.IsCenter = false;
    }
    

    public override void Exit()
    {
        base.Exit();
        HorizontalRoom.OnClick -= CheckHorizontalRoom;
        VerticalRoom.OnClick -= CheckVerticalRoom;
    }
}
