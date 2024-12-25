public class BattleStartState : BattleState
{
    public BattleStartState(Battle battle, BattleStateMachine stateMachine, string animBoolHash) : base(battle, stateMachine, animBoolHash)
    {

    }

    public override void Enter()
    {
        base.Enter();
        FirstAttack(battle.target.GetComponent<Enemy>().enemyData.AttackSpeed, _player.AbilityData.speed, battle.target.GetComponent<Enemy>());
    }


    private void FirstAttack(float a, float b, Enemy en)
    {
        if (a > b)
        {
            battle.PlayerAttack(en);
            battle.StateMachine.ChangeState(BattleStateEnum.MiddleState);
        }
        else
        {
            battle.EnemyAttack(en);
            battle.StateMachine.ChangeState(BattleStateEnum.MiddleState);
        }
    }

    public void ExitState()
    {
        StateMachine.ChangeState(BattleStateEnum.MiddleState);
    }
}