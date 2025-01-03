using UnityEngine;

public class BattleMiddleState : BattleState
{
    public BattleMiddleState(Battle battle, BattleStateMachine stateMachine, string animBoolHash) : base(battle, stateMachine, animBoolHash)
    {

    }


    public override void Enter()
    {
        base.Enter();
        Enemy_JH.OnClick += Attack;
    }

    private void Attack(GameObject en)
    {
        if (battle.turn == 0)
        {
            return;
        }

        if (Battle.Attack)
        {
            PlayerAttack();
        }
        else if (!Battle.Attack)
        {
            EnemyAttack();
        }
    }

    private void PlayerAttack()
    {
        Battle.OnPlayerAttack?.Invoke(battle.target.GetComponent<Enemy>());
    }

    private void EnemyAttack()
    {
        Battle.OnEnemyAttack?.Invoke(battle.target.GetComponent<Enemy>());
    }

    public void BattleEnd()
    {
        StateMachine.ChangeState(BattleStateEnum.EndState);
    }

    public override void Exit()
    {
        base.Exit();
        Enemy_JH.OnClick -= Attack;
    }
}