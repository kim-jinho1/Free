using System.Collections;
using UnityEngine;

public class IdleState_Enemy : Enemy_State
{
    private bool _startChoose;
    
    
    protected override void EnterState()
    {
        _startChoose = false;
        //여기서  idle 에니메이션이 n초간 실행되었다가 만약 CanAttack이 true면
        // 어텍 실행, 아니면 Hit state 전 까지 Idle 대기
        StartCoroutine(ChooseState());

    }
    public override void StateUpdate()
    {
        // 만약 후공이면 여기서 CanAttack이 들어 올때 까지 대기
        //CanAttack은 Player가 EnemyHealth.HpChange를 호출해서 데미지를 주었을 때 Hit 실행 후 

       
        if (_enemy.CanAttack)
        {
            _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Attack));
        }

    }

    IEnumerator ChooseState()
    {
        _enemy.animationCompo.PlayAnimation(AnimationType.Idle);
        yield return new WaitForSeconds(2f);
        _startChoose = true;

    }

    protected override void ExitState()
    {
        _startChoose = false;
    }

}
