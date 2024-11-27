using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState_Enemy : Enemy_State
{

    protected override void EnterState()
    {
        //_enemy.animationCompo.PlayAnimation(AnimationType.Attack);
        _enemy.CanAttack = false;
        StartCoroutine(Attack());
    }
    IEnumerator Attack()
    {
        _enemy.animationCompo.PlayAnimation(AnimationType.Attack);
        yield return new WaitForSeconds(_enemy.animationCompo.GetDuration("Attack"));
        _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Idle));
    }
    
}
