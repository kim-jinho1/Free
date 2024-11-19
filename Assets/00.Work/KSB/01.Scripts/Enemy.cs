using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Enemy_State currentState;
    public AnimationCompo_SB animationCompo;
    public StateCompo stateCompo;

    private void Awake()
    {
        stateCompo = GetComponent<StateCompo>();
        animationCompo = GetComponent <AnimationCompo_SB>();
    }
    void Start()
    {
        currentState = stateCompo.GetState(StateType.Idle);
    }

    // Update is called once per frame
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
    }
}
