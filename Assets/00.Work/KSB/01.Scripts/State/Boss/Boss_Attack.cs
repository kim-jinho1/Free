using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack : Enemy_State
{
    private int attackSucRate;
    Coroutine tempStatus;
    private void Awake()
    {
        attackSucRate = _enemy.enemyData.attackSucRate;
    }
    protected override void EnterState()
    {
        _enemy.animationCompo.PlayAnimation(AnimationType.Attack);
        _enemy.myTurn = false;
        AttackTry(attackSucRate);
    }



    private void AttackTry(int attackSucRng)
    {

        if (tempStatus != null)
        {
            return;
        }
        int Randnum = Random.Range(0, 100);

        if (Randnum >= attackSucRng)
        {
            tempStatus = StartCoroutine(Attack());
            tempStatus = null;
        }
        else
        {
            StartCoroutine(AttackMiss());
        }//
    }
    IEnumerator Attack()
    {
        _enemy.animationCompo.PlayAnimation(_enemy.ChooseAttack(_enemy.enemyData.GetBossMainSkillRng()));
        yield return new WaitForSeconds(_enemy.animationCompo.GetDuration("Attack"));
        _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Idle));
    }
    IEnumerator AttackMiss()
    {
        yield return new WaitForSeconds(_enemy.animationCompo.GetDuration("Miss"));
        _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Idle));

    }

    private void OnDisable()
    {
        StopCoroutine(tempStatus);
        tempStatus = null;

    }
}
