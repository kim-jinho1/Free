using System.Collections;
using UnityEngine;

public class HitState_Enemy : Enemy_State
{
    protected override void EnterState()
    {
        StartCoroutine(Hit());
    }

    IEnumerator Hit()
    {
        //_enemy.animationCompo.PlayAnimation(AnimationType.Hit);
        yield return new WaitForSeconds(_enemy.animationCompo.GetDuration("Hit"));
        _enemy.CanAttack = true;
        _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Idle));

    }
}
