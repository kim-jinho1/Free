using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack : Enemy_State
{
    private int attackSucRate;

    protected override void EnterState()
    {
        attackSucRate = _enemy.enemyData.AttackSucRate;
        _enemy.myTurn = false;

        if (_enemy.enemyData._isStunned)
            return;

        AttackTry(attackSucRate);
    }

    private void AttackTry(int attackSucRng)
    {
        int Randnum = Random.Range(0, 100);

        if (Randnum < attackSucRng)
        {
            StartCoroutine(Attack());
        }
        else
        {
            AttackMiss();
        }
    }

    IEnumerator Attack()
    {
        AnimationType type = _enemy.ChooseAttack(_enemy.enemyData._skill2_Rng, _enemy.enemyData._skill1_Rng);
        _enemy.animationCompo.PlayAnimation(type);
        yield return new WaitForSeconds(_enemy.animationCompo.GetDuration(type.ToString()));
        _enemy.enemyData.GetDamage(type);
        _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Idle));
    }

    private void AttackMiss()
    {
        print("MissÁ¢±Ù");
        _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Idle));
    }
}