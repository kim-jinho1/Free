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

        if(_enemy.enemyData._isStunned)
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
        AnimationType type = _enemy.ChooseAttack(_enemy.enemyData.GetBossMainSkillRng());
        print(type.ToString());
        _enemy.animationCompo.PlayAnimation(type);//보스는 attack이 2개라 특정 조건에 따라 나갈 attack이 결정됨
        yield return new WaitForSeconds(_enemy.animationCompo.GetDuration(type.ToString()));
        _enemy.enemyData.GetDamage(type);
        //_enemy.enemyData.GetDamage(type)이 데미지를 가지고 player 체력 감소 시키면 됨;
        
        _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Idle));
    }
    private void AttackMiss()
    {
        print("Miss접근");
        _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Idle));
    }

}
