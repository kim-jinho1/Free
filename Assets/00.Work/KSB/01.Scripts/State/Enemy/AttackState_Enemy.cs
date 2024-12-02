using System.Collections;
using UnityEngine;

public class AttackState_Enemy : Enemy_State
{

    private int attackSucRate;
    Coroutine tempStatus;

    protected override void EnterState()
    {
        print("JdfLKSDkfn");
        attackSucRate = _enemy.enemyData.AttackSucRate;
        _enemy.myTurn = false;

        if (_enemy.enemyData._isStunned)
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
        print("Attack접근");
        _enemy.animationCompo.PlayAnimation(AnimationType.Attack);
        yield return new WaitForSeconds(_enemy.animationCompo.GetDuration("Attack"));
        _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Idle));
    }
    private void AttackMiss()
    {
        print("Miss접근");
        _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Idle));

    }

}
