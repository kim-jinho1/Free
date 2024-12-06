using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStartState : BattleState
{
    public BattleStartState(Battle battle, BattleStateMachine stateMachine, string animBoolHash) : base(battle, stateMachine, animBoolHash)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        FirstAttack(battle.target.GetComponent<Enemy>().enemyData.AttackSpeed, _player.AbilityData.speed);
    }


    private void FirstAttack(float a, float b)
    {
        if (a>b)
        {
            battle.PlayerAttack();
            battle.StateMachine.ChangeState(BattleStateEnum.MiddleState);
        }
        else
        {
            battle.EnemyAttack();
            battle.StateMachine.ChangeState(BattleStateEnum.MiddleState);
        }
    }

    public void ExitState()
    {
        StateMachine.ChangeState(BattleStateEnum.MiddleState);
    }
}