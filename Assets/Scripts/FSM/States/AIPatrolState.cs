using UnityEngine;

public class AIPatrolState : AIState
{
    Vector3 dest = Vector3.zero;
    public AIPatrolState(StateAgent agent) : base(agent)
    {
        //CreateTransistion();
    }
    public override void OnEnter()
    {
        dest = NavNode.GetRandomNavNode().transform.position;
        agent.movement.Destination = dest;
        agent.movement.Resume();
    }
    public override void OnUpdate()
    {
        float distance = (agent.transform.position - dest).magnitude;
        if(distance < 1.5f)
        {
            agent.stateMachine.SetState(nameof(AIIdleState));
        }
    }
    public override void OnExit()
    {
        //
    }
}
