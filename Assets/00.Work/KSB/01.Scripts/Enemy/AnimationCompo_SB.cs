using System.Runtime.CompilerServices;
using UnityEngine;

public class AnimationCompo_SB : MonoBehaviour
{
    public Animator _animator;
    RuntimeAnimatorController _controller;
    Enemy _enemy;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemy = GetComponentInParent<Enemy>();
       
    }

    public void EndPoint()
    {
        _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Idle));
    }
    public void StopAnimation()
    {
        _enemy.animationCompo._animator.speed = 0f;
    }
    public void PlayAnimation(AnimationType type)
    {
        switch (type)
        {
            case AnimationType.Idle:
                Play("Idle");
                break;
            case AnimationType.Attack:
                Play("Attack");
                break;
            case AnimationType.Attack2:
                Play("Attack2");
                break;
            case AnimationType.Death:
                Play("Death");
                break;
            case AnimationType.Hit:
                Play("Hit");
                break;
            case AnimationType.Miss:
                Play("Idle");
                break;
            default:
                Debug.Log("Not Defined");
                break;
        }
    }
    public void Play(string type)
    {
        _animator.Play(type);
    }
}

public enum AnimationType
{
    Idle,
    Attack,
    Attack2,
    Death,
    Hit,
    Miss



}

