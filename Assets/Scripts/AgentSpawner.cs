using UnityEngine;

public class AgentSpawner : MonoBehaviour
{
    [SerializeField] AIAgent[] agents;
    [SerializeField] LayerMask layerMask;
    [SerializeField, Range(0,5)] float USScale = 0;

    int index = 0;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)) index = ++index % agents.Length;
        if (Input.GetMouseButtonDown(0) || (Input.GetMouseButton(0) && Input.GetKey(KeyCode.Space)))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hitInfo, 100,layerMask))
            {
                Instantiate(agents[index], hitInfo.point + Random.onUnitSphere * USScale * Random.value,
                    Quaternion.identity);
            }
        }

    }
}
