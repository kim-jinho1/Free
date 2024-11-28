using System.Collections;
using UnityEngine;

public class IdleState_Enemy : Enemy_State
{
   
    protected override void EnterState()
    {
      _enemy.animationCompo.PlayAnimation(AnimationType.Idle);
    }
    public override void StateUpdate()
    {

        if (_enemy.myTurn)
        {
            print("½ÇÇà");
            _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Attack));
        }
    
    }

    
}
