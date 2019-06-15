using UnityEngine;
using UnityEngine.AI;

public class PedestrianMovement : MonoBehaviour
{
    public GameObject destinationObject;

    public float finalGoalAccuracy = 3f;
    public Vector3 finalGoalPosition;

    public float speed = 3.0f;
    private NavMeshAgent agent;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();  
        agent.SetDestination(finalGoalPosition); // Ustawia punkt docelowy
        agent.speed = speed; // Ustawia prędkość, ustawioną przedtem w PedestrianSpawnManager
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
