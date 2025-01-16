using UnityEngine;

public class AutomonosAgent : AIAgent
{
    public Perception perception;
    void Update()
    {
        movement.ApplyForce(Vector3.forward * 10);
        transform.position = Utilities.Wrap(transform.position,
            new Vector3(-10, -10, -10), new Vector3(10, 10, 10));

        Debug.DrawRay(transform.position,transform.forward * perception.maxDistance,Color.green);
        var gameObjects = perception.GetGameObjects();
        foreach (var go in gameObjects)
        {
            Debug.DrawLine(transform.position,go.transform.position,Color.red);
        }
    }
}
