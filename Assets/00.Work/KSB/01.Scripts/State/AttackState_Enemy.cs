using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState_Enemy : Enemy_State
{

    protected override void EnterState()
    {
        _enemy.animationCompo.PlayAnimation(AnimationType.Attack);
        StartCoroutine(Attack());
   
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(_enemy.animationCompo.GetDuration("Attack"));
        _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Idle));
    }
    
}
