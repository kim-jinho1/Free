using System.Collections;
using UnityEngine;

public class AttackState_Enemy : Enemy_State
{

    private int attackSucRate;
    Coroutine tempStatus;
    private void Start()
    {
        if(_enemy ==null|| _enemy.enemyData)
        {
            print("null1");
        }
        else
        {
            print("null2");
        }
     
    }
    protected override void EnterState()
    {
        print("JdfLKSDkfn");
        attackSucRate = _enemy.enemyData.attackSucRate;
      //  _enemy.animationCompo.PlayAnimation(AnimationType.Attack);
        _enemy.myTurn = false;
        AttackTry(attackSucRate);
    }


   
    private void AttackTry(int attackSucRng)
    {

        if(tempStatus != null)
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
        print("Attack접근");
       // _enemy.animationCompo.PlayAnimation(AnimationType.Attack);
        yield return new WaitForSeconds(1f/*_enemy.animationCompo.GetDuration("Attack")*/);
        _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Idle));
    }
    IEnumerator AttackMiss()
    {
        print("Miss접근");
        yield return new WaitForSeconds(1f);//_enemy.animationCompo.GetDuration("Miss"));
        _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Idle));

    }

}
