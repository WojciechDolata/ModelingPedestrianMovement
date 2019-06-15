using UnityEngine;
using UnityEngine.AI;

public class PedestrianMovement : MonoBehaviour
{
    public GameObject destinationObject;

    public float finalGoalAccuracy = 3f;
    public Vector3 finalGoalPosition;

    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(finalGoalPosition); // probably initial goal is not needed, if so we have to delete it from PedestrianMovement
    }

    void Update()
    {

        if (distance(finalGoalPosition, this.transform.position) < finalGoalAccuracy)
        {
            Destroy(this.gameObject);
        }
    }

    float distance(Vector3 v1, Vector3 v2)
    {
        return Mathf.Sqrt(Mathf.Pow(v1.x - v2.x, 2) + Mathf.Pow(v1.y - v2.y, 2) + Mathf.Pow(v1.z - v2.z, 2));
    }
}
