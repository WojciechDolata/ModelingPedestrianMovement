using UnityEngine;
using UnityEngine.AI;

public class CarMovement : MonoBehaviour
{
    public Vector3 goalPosition;
    public float accuracy = 0.2f;
    public float minSpeed = 8;
    public float maxSpeed = 13;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        goalPosition = new Vector3(goalPosition.x, 8.32f, goalPosition.z); //should rather take goals based on objects created in scene manager,
        agent.SetDestination(goalPosition);
        agent.speed = Random.Range(8, 13);
    }

    // Update is called once per frame
    void Update()
    {
        if (distance(goalPosition, this.transform.position) < accuracy)
        {
            Destroy(this.gameObject);
        }
    }

    float distance(Vector3 v1, Vector3 v2) // distance between 2 3D Vectors
    {
        return Mathf.Sqrt(Mathf.Pow(v1.x - v2.x, 2) + Mathf.Pow(v1.y - v2.y, 2) + Mathf.Pow(v1.z - v2.z, 2));
    }
}
