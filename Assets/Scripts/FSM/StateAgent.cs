using UnityEngine;

public class StateAgent : AIAgent
{
    [SerializeField] Perception perception;

    public StateMachine stateMachine = new StateMachine();

    public ValueRef<float> timer = new ValueRef<float>();
    public ValueRef<float> health = new ValueRef<float>();
    public ValueRef<float> destDist = new ValueRef<float>();

    public ValueRef<bool> enemySeen = new ValueRef<bool>();
    public ValueRef<float> enemyDist = new ValueRef<float>();

    public AIAgent enemy;
    private void Start()
    {
        stateMachine.AddState(nameof(AIIdleState), new AIIdleState(this));
        stateMachine.AddState(nameof(AIPatrolState), new AIPatrolState(this));
        stateMachine.AddState(nameof(AIChaseState), new AIChaseState(this));
        stateMachine.AddState(nameof(AIAttackState), new AIAttackState(this));
        stateMachine.AddState(nameof(AIDeathState), new AIDeathState(this));

        stateMachine.SetState(nameof(AIIdleState));
    }

    private void Update()
    {
        timer.value -= Time.deltaTime;
        stateMachine.Update();
        if (perception != null)
        {
            var gameObjects = perception.GetGameObjects();
            enemySeen.value = gameObjects.Length > 0;
            if (gameObjects.Length > 0)
            {
                gameObjects[0].TryGetComponent<AIAgent>(out enemy);
                enemyDist.value = transform.position.DistanceXZ(gameObjects[0].transform.position);
                //movement.Destination = gameObjects[0].transform.position;
            }
        }
    }
    public void OnDamage(float damage)
    {
        health.value -= damage;

        if (health <= 0) stateMachine.SetState(nameof(AIDeathState));
        else stateMachine.SetState(nameof(AIHitState));
    }
    public void Attack()
    {
        var colliders = Physics.OverlapSphere(transform.position, 1);
        foreach (var collider in colliders)
        {
            if (collider.gameObject != enemy) continue;

            if (collider.gameObject.TryGetComponent<StateAgent>(out var agent))
                agent.OnDamage(Random.Range(20, 50));
        }
    }
    private void OnGUI()
    {
        // draw label of current state above agent
        GUI.backgroundColor = Color.black;
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        Rect rect = new Rect(0, 0, 100, 20);
        // get point above agent
        Vector3 point = Camera.main.WorldToScreenPoint(transform.position);
        rect.x = point.x - (rect.width / 2);
        rect.y = Screen.height - point.y - rect.height - 20;
        // draw label with current state name
        GUI.Label(rect, stateMachine.CurrentState.Name);
    }
}
