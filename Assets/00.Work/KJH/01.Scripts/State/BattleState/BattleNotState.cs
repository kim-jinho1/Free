using UnityEngine;

public class BattleNotState : BattleState
{
    public BattleNotState(Battle battle, BattleStateMachine stateMachine, string animBoolHash) : base(battle, stateMachine, animBoolHash)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        Enemy_JH.OnClick += Battle;
    }

    private void Battle(GameObject obj)
    {
        battle.target = obj;
        StateMachine.ChangeState(BattleStateEnum.StartState);
        _player.StateMachine.ChangeState(PlayerStateEnum.Battle);
    }

    public override void Exit()
    {
        base.Exit();
    }
}