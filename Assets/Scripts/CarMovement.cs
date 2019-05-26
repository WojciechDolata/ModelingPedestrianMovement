using UnityEngine;
using UnityEngine.AI;

public class CarMovement : MonoBehaviour
{
    public GameObject goal;
    private Vector3 goalPosition;
    private NavMeshAgent agent;
    public float accuracy = 0.2f;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(8, 13);
        agent = this.GetComponent<NavMeshAgent>();
        goalPosition = new Vector3(
        Random.Range(goal.transform.position.x, goal.transform.position.x),
        8.32f,
        Random.Range(goal.transform.position.z, goal.transform.position.z));
        agent.SetDestination(goalPosition);
        agent.speed = this.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Mathf.Abs(goalPosition.x - this.transform.position.x) < accuracy && Mathf.Abs(goalPosition.z - this.transform.position.z) < accuracy))
        {
            Destroy(this.gameObject);
        }
    }
}
