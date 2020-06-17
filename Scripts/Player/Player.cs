using Assets.Scripts;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private State _currentState;

    public TimerBehaviour TimerBehaviour { get; set; }
    public PlayerMove[] PlayerMoves { get; set; } = new PlayerMove[4];
    public MoveToken[] MoveTokens { get; set; } = new MoveToken[4];

    public int CurrentPhase { get; set; } = 0;
    public bool InCoroutine { get; set; } = false;
    public bool InTurn { get; set; } = false;

    private void Start() => SetState(new IdleState(this));

    private void Update() => _currentState.Tick();

    public void SetState(State state)
    {
        _currentState?.OnStateExit();

        _currentState = state;

        _currentState.OnStateEnter();

        _currentState.Execute();
    }

    public void HandleTimerEnd()
    {
        _currentState.SetMoves(MoveTokens);
        InTurn = true;
    }

}
