using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public Action OnPlayerAttack;
    public Action OnEnemyAttack;
    
    public bool Attack {get; set;}
    
    public Animator Animator { get; private set; }
    
    public BattleStateMachine StateMachine { get; private set; }


    private void Awake()
    {
        OnPlayerAttack += PlayerAttack;
        OnEnemyAttack += EnemyAttack;

        StateMachine.AddState(BattleStateEnum.StartState, new BattleStartState(this, StateMachine, "Idle"));
        StateMachine.AddState(BattleStateEnum.MiddleState, new BattleMiddleState(this, StateMachine, "Attack"));
        StateMachine.AddState(BattleStateEnum.EndState, new BattleEndState(this, StateMachine, "HorizontalMove"));
    }

    private void PlayerAttack()
    {
        
    }

    private void EnemyAttack()
    {
        
    }
}
