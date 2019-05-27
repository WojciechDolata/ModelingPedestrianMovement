using UnityEngine;
using UnityEngine.AI;

public class MoveToGoal : MonoBehaviour
{
    public GameObject destinationObject;
    private Vector3 destinationSize;
    public Vector3 initialGoalPosition;
    private Vector3 goalPosition;
    private NavMeshAgent agent;
    public float accuracy = 2f;
    public float initialGoalAccuracy = 15f;
    bool changed = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        Vector3 agentSize = this.GetComponent<Renderer>().bounds.size;
        destinationSize = destinationObject.GetComponent<Renderer>().bounds.size;
        goalPosition = new Vector3(
            destinationObject.transform.position.x + Random.Range(-destinationSize.x / 2 + agentSize.x, destinationSize.x / 2 - agentSize.x),
            8.32f,
            destinationObject.transform.position.z + Random.Range(-destinationSize.z / 2 + agentSize.z, destinationSize.z / 2 - agentSize.z));
        agent.SetDestination(initialGoalPosition);
    }

    void Update()
    {
        if ((distance(initialGoalPosition, this.transform.position) < initialGoalAccuracy) && !changed)
        {
            agent.SetDestination(goalPosition);
            changed = true;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (distance(goalPosition, this.transform.position) < accuracy)
        {
            Destroy(this.gameObject);
        }
    }

    float distance(Vector3 v1, Vector3 v2)
    {
        return Mathf.Sqrt(Mathf.Pow(v1.x - v2.x, 2) + Mathf.Pow(v1.y - v2.y, 2) + Mathf.Pow(v1.z - v2.z, 2));
    }
}
