using UnityEngine;

public class AnimationCompo_SB : MonoBehaviour
{
    public Animator _animator;
    RuntimeAnimatorController _controller;



    public float GetDuration(string name)
    {
        AnimationClip clip = null;
        foreach (var animClip in _controller.animationClips)
        {
            if (animClip.name == name)
            {
                clip = animClip;
                break;
            }
        }
        return clip.length;
    }




    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _controller = _animator.runtimeAnimatorController;

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

