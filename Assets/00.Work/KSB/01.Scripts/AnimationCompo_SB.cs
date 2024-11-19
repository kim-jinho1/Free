using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCompo_SB : MonoBehaviour
{
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void PlayAnimation(AnimationType type)
    {
        switch (type)
        {
            case AnimationType.Idle:
                Play("Idle");
                break;
            case AnimationType.Attack1:
                Play("Idle");
                break;
            case AnimationType.Attack2:
                Play("Attack2");
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
    Attack1,
    Attack2,
    Attack3,

}

