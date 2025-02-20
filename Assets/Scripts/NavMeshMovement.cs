using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshMovement : Movement
{
    [SerializeField] public NavMeshAgent nvAgent;

    public override Vector3 Velocity { get => nvAgent.velocity; set => nvAgent.velocity = value; }
    public override Vector3 Destination { get => nvAgent.destination; set => nvAgent.destination = value; }

    private void Update()
    {
        nvAgent.speed = data.maxSpeed;
        nvAgent.acceleration = data.maxForce;
        nvAgent.angularSpeed = data.turnRate;
    }
    public override void ApplyForce(Vector3 force)
    {
        
    }

    public override void MoveTowards(Vector3 position)
    {
        nvAgent.destination = position;
    }
    public override void Stop()
    {
        nvAgent.isStopped = true;
    }
    public override void Resume()
    {
        nvAgent.isStopped = false;
    }
}
