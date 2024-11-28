using System.Collections;
using UnityEngine;

public class HitState_Enemy : Enemy_State
{
    Coroutine tempStatus;
    protected override void EnterState()
    {
        print("¾ÆÆÄ");
        if(tempStatus !=null)
            return;
        tempStatus = StartCoroutine(Hit());
    }

    IEnumerator Hit()
    {

        _enemy.animationCompo.PlayAnimation(AnimationType.Hit);
        yield return new WaitForSeconds(_enemy.animationCompo.GetDuration("Hit")*2); ;
        _enemy.myTurn = true;
        tempStatus = null; 
        _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Idle));

    }
}
