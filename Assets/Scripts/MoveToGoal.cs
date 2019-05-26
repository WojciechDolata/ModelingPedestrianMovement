using UnityEngine;
using UnityEngine.AI;

public class MoveToGoal : MonoBehaviour
{
    public GameObject destinationObject;
    private Vector3 destinationSize;
    public Vector3 initialGoalPosition;
    private Vector3 goalPosition;
    private NavMeshAgent agent;
    public float accuracy = 0.2f;
    public float initialGoalAccuracy = 15f;
    bool changed = false;

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
        agent.SetDestination(initialGoalPosition);
    }

    void Update()
    {
        if ((Mathf.Abs(initialGoalPosition.x - this.transform.position.x) < initialGoalAccuracy && Mathf.Abs(initialGoalPosition.z - this.transform.position.z) < initialGoalAccuracy) && !changed)
        {
            agent.SetDestination(goalPosition);
            changed = true;
        }
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
