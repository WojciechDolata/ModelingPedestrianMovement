using UnityEngine;
using UnityEngine.AI;

public class PedestrianMovement : MonoBehaviour
{
    public GameObject destinationObject;
    public Vector3 initialGoalPosition;
    public float initialGoalAccuracy = 15f;

    public float finalGoalAccuracy = 2f;
    public Vector3 finalGoalPosition;

    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        setFinalTarget();
        agent.SetDestination(initialGoalPosition);
    }

    void Update()
    {
        if ((distance(initialGoalPosition, this.transform.position) < initialGoalAccuracy))
        {
            agent.SetDestination(finalGoalPosition);
        }

        if (distance(finalGoalPosition, this.transform.position) < finalGoalAccuracy)
        {
            Destroy(this.gameObject);
        }
    }

    void setFinalTarget()
    {
        Vector3 agentSize = this.GetComponent<Renderer>().bounds.size;
        Vector3 destinationSize = destinationObject.GetComponent<Renderer>().bounds.size;
        finalGoalPosition = new Vector3(
            destinationObject.transform.position.x + Random.Range(-destinationSize.x / 2 + agentSize.x, destinationSize.x / 2 - agentSize.x),
            8.32f,
            destinationObject.transform.position.z + Random.Range(-destinationSize.z / 2 + agentSize.z, destinationSize.z / 2 - agentSize.z));
    }

    float distance(Vector3 v1, Vector3 v2)
    {
        return Mathf.Sqrt(Mathf.Pow(v1.x - v2.x, 2) + Mathf.Pow(v1.y - v2.y, 2) + Mathf.Pow(v1.z - v2.z, 2));
    }
}
