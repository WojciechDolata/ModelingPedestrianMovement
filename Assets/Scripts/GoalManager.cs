using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public GameObject goal;
    public GameObject goalPrefab;
    public float goalX;
    public float goalY;
    public bool success = false;

    // Start is called before the first frame update
    void Start()
    {
        goal = Instantiate(goalPrefab, new Vector2(goalX, goalY), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(transform.position.x-goal.transform.position.x) < 0.2)
        {
            goalX += 10.0f;
            goalY = Random.Range(4f, 6f);

            goal.transform.position = new Vector2(goalX, goalY);
            success = true;
        }
    }
}
