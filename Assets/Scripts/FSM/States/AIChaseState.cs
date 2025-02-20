using UnityEngine;

public class AIChaseState : AIState
{
    public AIChaseState(StateAgent agent) : base(agent)
    {
        
    }

    public override void OnEnter()
    {
        agent.movement.Resume();
    }
    public override void OnUpdate()
    {
        
    }
    public override void OnExit()
    {
        
    }
}
