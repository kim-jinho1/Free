using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState_Enemy : Enemy_State
{
    protected override void EnterState()
    {
        
        _enemy.animationCompo.PlayAnimation(AnimationType.Death);
    }
}
