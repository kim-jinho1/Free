using System.Collections;
using UnityEngine;

public class IdleState_Enemy : Enemy_State
{
    private bool _startChoose;
    
    
    protected override void EnterState()
    {
        _startChoose = false;
        //���⼭  idle ���ϸ��̼��� n�ʰ� ����Ǿ��ٰ� ���� CanAttack�� true��
        // ���� ����, �ƴϸ� Hit state �� ���� Idle ���
        StartCoroutine(ChooseState());

    }
    public override void StateUpdate()
    {
        // ���� �İ��̸� ���⼭ CanAttack�� ��� �ö� ���� ���
        //CanAttack�� Player�� EnemyHealth.HpChange�� ȣ���ؼ� �������� �־��� �� Hit ���� �� 

       
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
