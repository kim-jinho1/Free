using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    public PlayerStateMachine StateMachine;
    public Player Player;
    public int AnimBoolHash;

    public bool IsTirggcalled;
    
    protected Animator Animator;

    public PlayerState(Player player, PlayerStateMachine stateMachine, string animBoolHash)
    {
        Player = player;
        StateMachine = stateMachine;
        AnimBoolHash = Animator.StringToHash(animBoolHash);

        Animator = player.Animator;
    }
    
    
    
    public virtual void PlayerUpdate()
    {

    }

    public virtual void Enter()
    {
        //Animator.SetBool(AnimBoolHash,true);
        IsTirggcalled = false;
    }


    public virtual void Exit()
    {
        //Animator.SetBool(AnimBoolHash, false);
    }

    public void Tirggercalled()
    {
        IsTirggcalled = true;
    }
}
