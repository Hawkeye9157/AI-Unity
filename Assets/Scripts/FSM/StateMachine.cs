using Mono.Cecil.Cil;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class StateMachine
{
    private Dictionary<string, AIState> states = new Dictionary<string, AIState>();
    public AIState CurrentState { get; private set; }
    public void Update()
    {
        CurrentState?.OnUpdate();
    }
    public void AddState(string name, AIState state)
    {
        Debug.Assert(!states.ContainsKey(name) && state != null, "You fucked up somewhere. Good luck");
        states[name] = state;
    }
    public void SetState(string name)
    {
        Debug.Assert(states.ContainsKey(name), "You fucked up somewhere. Good luck");
        var newState = states[name];
        if (newState == CurrentState) return;

        CurrentState?.OnExit();
        CurrentState = newState;
        CurrentState.OnEnter();
    }
}
