using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMiddleState : BattleState
{
    public BattleMiddleState(Battle battle, BattleStateMachine stateMachine, string animBoolHash) : base(battle, stateMachine, animBoolHash)
    {
        
    }
    
    private void Attack()
    {
        if (Battle.Attack)
        {
            PlayerAttack();
        }
        else
        {
            EnemyAttack();
        }
    }

    private void PlayerAttack()
    {
        Battle.OnPlayerAttack?.Invoke();
    }

    private void EnemyAttack()
    {
        Battle.OnEnemyAttack?.Invoke();
    }

    public void Exit()
    {
        StateMachine.ChangeState(BattleStateEnum.EndState);
    }
}
