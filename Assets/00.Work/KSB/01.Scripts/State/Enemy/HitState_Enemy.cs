using System.Collections;
using UnityEngine;

public class HitState_Enemy : Enemy_State
{

    protected override void EnterState()
    {
        print("����");
         StartCoroutine(Hit());//�°� ���� _enemy.myTurn = true;�� �ǰ� Idle�� �Ѿ��
                               // idle stateupdate�� ���� Attack�� �����
            
                                
    }

    IEnumerator Hit()
    {

        _enemy.animationCompo.PlayAnimation(AnimationType.Hit);
        yield return new WaitForSeconds(_enemy.animationCompo.GetDuration("Hit")*2); ;
        _enemy.myTurn = true;
        _enemy.enemyData.Speed_Passive_Skill();
        _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Idle));
    }
}
