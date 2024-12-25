using UnityEngine;

public class BattleState
{
    public Battle battle;
    public Player _player;
    
    public BattleStateMachine StateMachine;
    public Battle Battle;
    public int AnimBoolHash;

    public bool IsTirggcalled;
    
    protected Animator Animator;

    
    public BattleState(Battle battle, BattleStateMachine stateMachine, string animBoolHash)
    {
        Battle = battle;
        StateMachine = stateMachine;
        //AnimBoolHash = Animator.StringToHash(animBoolHash);

       // Animator = battle.Animator;
    }
    
    public virtual void Update()
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
        //IsTirggcalled = true;
    }
}
