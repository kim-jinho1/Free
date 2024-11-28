using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack : Enemy_State
{
    private int attackSucRate;
    Coroutine tempStatus;

    protected override void EnterState()
    {
        attackSucRate = _enemy.enemyData.AttackSucRate;
        _enemy.myTurn = false;

        if(_enemy.enemyData._isStunned)
        return;
        AttackTry(attackSucRate);
    }

    private void AttackTry(int attackSucRng)
    {

        if (tempStatus != null)
        {
            return;
        }
        int Randnum = Random.Range(0, 100);

        if (Randnum < attackSucRng)
        {
            tempStatus = StartCoroutine(Attack());
            tempStatus = null;
        }
        else
        {
           AttackMiss();
        }
    }
    IEnumerator Attack()
    {
        print("Attack");
        _enemy.animationCompo.PlayAnimation(_enemy.ChooseAttack(_enemy.enemyData.GetBossMainSkillRng()));
        yield return new WaitForSeconds(_enemy.animationCompo.GetDuration("Attack"));
        _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Idle));
    }
    private void AttackMiss()
    {
        print("MissÁ¢±Ù");
        _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Idle));
    }

}
