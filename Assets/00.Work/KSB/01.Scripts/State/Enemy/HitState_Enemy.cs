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
        print("����");
        Hit();//�°� ���� _enemy.myTurn = true;�� �ǰ� Idle�� �Ѿ��
                               // idle stateupdate�� ���� Attack�� �����
            
                                
    }

    private void Hit()
    {

        _enemy.animationCompo.PlayAnimation(AnimationType.Hit);
        _enemy.myTurn = true;
     
    
    }
}
