using System.Collections;
using UnityEngine;

public class AttackState_Enemy : Enemy_State
{

    private int attackSucRate;
    protected override void EnterState() //attack 스테이트 실행될때 AttackTry메서드를 실행 시킴 
                                         //만약  attackSucRate 확률에 따라 attack을 하거나 Miss가 남
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
           Attack();
        }
        else
        {
            AttackMiss();
        }
    }
    public void Attack()
    {
        print("Attack접근");
        _enemy.animationCompo.PlayAnimation(AnimationType.Attack);
        _enemy.enemyData.GetDamage(AnimationType.Attack);//이거 가지고 플레이어 데미지 감소 _enemy.animationCompo.GetDuration("Attack")
        _enemy.enemyData.Hp_Passive_Skill();
      
      
    }
    private void AttackMiss()
    {
        print("Miss접근");
        _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Idle));

    }

}
