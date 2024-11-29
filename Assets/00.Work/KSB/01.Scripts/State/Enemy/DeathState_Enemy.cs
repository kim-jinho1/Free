using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState_Enemy : Enemy_State
{
    protected override void EnterState()
    {
        StartCoroutine(Death());
      
    }

    IEnumerator Death()
    {
        _enemy.animationCompo.PlayAnimation(AnimationType.Death);
        yield return new WaitForSeconds(_enemy.animationCompo.GetDuration("Death"));
        _enemy.animationCompo._animator.speed = 0f;

    }
}
