using System.Collections;
using UnityEngine;

public class AttackState_Enemy : Enemy_State
{

    private int attackSucRate;
    protected override void EnterState() //attack ������Ʈ ����ɶ� AttackTry�޼��带 ���� ��Ŵ 
                                         //����  attackSucRate Ȯ���� ���� attack�� �ϰų� Miss�� ��
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
        print("Attack����");
        _enemy.animationCompo.PlayAnimation(AnimationType.Attack);
        _enemy.enemyData.GetDamage(AnimationType.Attack);//�̰� ������ �÷��̾� ������ ���� _enemy.animationCompo.GetDuration("Attack")
        _enemy.enemyData.Hp_Passive_Skill();
      
      
    }
    private void AttackMiss()
    {
        print("Miss����");
        _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Idle));

    }

}
