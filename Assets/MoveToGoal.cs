using UnityEngine;
using UnityEngine.AI;

public class MoveToGoal : MonoBehaviour
{
    public GameObject destinationObject;
    private Vector3 destinationSize;
    private Vector3 goalPosition;
    private NavMeshAgent agent;
    public float accuracy = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        Vector3 agentSize = this.GetComponent<Renderer>().bounds.size;
        destinationSize = destinationObject.GetComponent<Renderer>().bounds.size;
        goalPosition = new Vector3(
            Random.Range(destinationObject.transform.position.x - destinationSize.x / 2 + agentSize.x, destinationObject.transform.position.x + destinationSize.x / 2 - agentSize.x),
            8.32f,
            Random.Range(destinationObject.transform.position.z - destinationSize.z / 2 + agentSize.z, destinationObject.transform.position.z + destinationSize.z / 2 - agentSize.z));
        agent.SetDestination(goalPosition);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if ((Mathf.Abs(goalPosition.x - this.transform.position.x) < accuracy && Mathf.Abs(goalPosition.z - this.transform.position.z) < accuracy))
        {
            Destroy(this.gameObject);
        }

    }
}
