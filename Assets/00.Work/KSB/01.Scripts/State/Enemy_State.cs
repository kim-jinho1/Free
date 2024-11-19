using UnityEngine;
using UnityEngine.Events;

public abstract class Enemy_State : MonoBehaviour
{
    protected Enemy _enemy;
    public UnityEvent OnEnter, OnExit;  //State ³ª°¥¶§
    public void InitializeState(Enemy enemy)
    {
        _enemy = enemy;
    }
    
    public void Enter()
    {
          EnterState();
    }

    protected virtual void EnterState()
    {
        _enemy.animationCompo.PlayAnimation(AnimationType.Idle);
        OnEnter?.Invoke();
      
    }
    public virtual void StateUpdate()
    {

    }

    public virtual void StateFixedUpdate()
    {

    }

    public void Exit()
    {

        OnExit?.Invoke();
        ExitState();
    }

    protected virtual void ExitState()
    {
    }
}
