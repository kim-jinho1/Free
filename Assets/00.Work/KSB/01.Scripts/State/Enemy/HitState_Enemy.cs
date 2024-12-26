using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class HitState_Enemy : Enemy_State
{
    public override void StateUpdate()
    {
        if(_enemy.enemyHealth.CurrentHp<=0)
        {
            _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Death));
        }
    }
    protected override void EnterState()
    {
        print("아파");
        Hit();//맞고 나면 _enemy.myTurn = true;가 되고 Idle로 넘어가서
                               // idle stateupdate에 따라서 Attack이 실행됨
            
                                
    }

    private void Hit()
    {

        _enemy.animationCompo.PlayAnimation(AnimationType.Hit);
        _enemy.myTurn = true;
     
    
    }
}
