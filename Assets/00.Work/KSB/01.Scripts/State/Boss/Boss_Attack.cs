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

      

        AttackTry(attackSucRate);
    }

    private void AttackTry(int attackSucRng)
    {
        int Randnum = Random.Range(0, 100);

        if (Randnum < attackSucRng)
        {
           Attack();
        }
        else
        {
            AttackMiss();
        }
    }

    private void Attack()
    {
        AnimationType type = _enemy.ChooseAttack(_enemy.enemyData.Skill2_Rng, _enemy.enemyData.Skill1_Rng);
        print(type);
        if (type.ToString() == "Miss")
        {
            print("Miss");
            AttackMiss();
        }
        else
        {
            _enemy.animationCompo.PlayAnimation(type);
            _enemy.enemyData.GetDamage(type);
            _enemy.enemyData.Hp_Passive_Skill(_enemy.enemyData.Hp_Passive_Rng);

        }
        
    }

    private void AttackMiss()
    {
        print("MissÁ¢±Ù");
        _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Idle));
    }
}