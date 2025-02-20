using System.Collections;
using UnityEngine;

public class AIAttackState : AIState
{
    float attackTimer;
    bool hasAttacked;
    public AIAttackState(StateAgent agent) : base(agent)
    {
    }

    public override void OnEnter()
    {
        attackTimer = 1;
        agent.timer.value = 2;
        agent.movement.Stop();
        //agent.animator.SetTrigger("Attack");
    }

    public override void OnUpdate()
    {
        attackTimer -= Time.deltaTime;
        if(attackTimer <= 0 && !hasAttacked)
        {
            hasAttacked = true;
            agent.Attack();
        }
    }
    public override void OnExit()
    {

    }

}
