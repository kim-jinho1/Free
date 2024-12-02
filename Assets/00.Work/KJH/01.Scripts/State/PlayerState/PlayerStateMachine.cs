using System.Collections.Generic;

public enum PlayerStateEnum
{
    Idle,
    HorizontalMove,
    VerticalMove,
    Attack,
    UI
}

public class PlayerStateMachine
{
    public PlayerState currentState;

    public Dictionary<PlayerStateEnum, PlayerState> PlayerStates = new();

    public void Initialize(PlayerStateEnum state)
    {
        currentState = PlayerStates[state];
        currentState.Enter();
    }

    public void AddState(PlayerStateEnum stateEnum, PlayerState state)
    {
        PlayerStates.Add(stateEnum, state);
    }

    public void ChangeState(PlayerStateEnum stateEnum)
    {
        currentState.Exit();
        currentState = PlayerStates[stateEnum];
        currentState.Enter();
    }
}
