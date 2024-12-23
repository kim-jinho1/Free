using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState_Enemy : Enemy_State
{
    protected override void EnterState()
    {
       Death();
      
    }

    public void Death()
    {
        _enemy.animationCompo.PlayAnimation(AnimationType.Death);

       

    }
}
