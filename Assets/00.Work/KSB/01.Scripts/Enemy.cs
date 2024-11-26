using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Enemy_State currentState;
    public AnimationCompo_SB animationCompo;
    public StateCompo stateCompo;
    public EnemyData enemyData;
    public EnemyHealth enemyHealth;
    public bool CanAttack;
    private void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        stateCompo = GetComponentInChildren<StateCompo>();
        animationCompo = GetComponentInChildren <AnimationCompo_SB>();
        enemyData = GetComponentInChildren<EnemyData>();
      
    }
    void Start()
    {
        currentState = stateCompo.GetState(StateType.Idle);
    }
    void Update()
    {
        currentState.StateUpdate();
    }

    private void FixedUpdate()
    {
        currentState.StateFixedUpdate();
    }
    public void TransitionState(Enemy_State InputState)
    {
        if(InputState == null)
        return;
        if (currentState == InputState)
            return;
      
        currentState.Exit();
        currentState = InputState;
      
        currentState.Enter();
        currentState.InitializeState(this);
    }

   
}
