using UnityEngine;

public class AIDeathState : AIState
{
    public AIDeathState(StateAgent agent) : base(agent)
    {
    }

    public override void OnEnter()
    {
        agent.movement.Stop();
    }

    public override void OnExit()
    {
        //there is no exit
    }

    public override void OnUpdate()
    {
        //death doesn't change
    }
}
