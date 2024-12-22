using System.Collections;
using UnityEngine;

public class HitState_Enemy : Enemy_State
{

    protected override void EnterState()
    {
        print("아파");
         StartCoroutine(Hit());//맞고 나면 _enemy.myTurn = true;가 되고 Idle로 넘어가서
                               // idle stateupdate에 따라서 Attack이 실행됨
            
                                
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
