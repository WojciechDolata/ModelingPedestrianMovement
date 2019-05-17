using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public GameObject goalPrefab;
    private float minDistance = 0.1f; // minimal distance to required to accept reaching goal
    public bool success = false;
    public List<GameObject> goals; // should pick 1 path from all possible paths

    public GameObject getCurrentGoal()
    {
        return goals[0];
    }
    
    public void nextGoal()
    {
        goals.RemoveAt(0); // may not move head of list
        success = true; // piotr?!@?!?!
    }

    // Start is called before the first frame update
    void Start()
    {
        System.Random randomizer = new System.Random();
        int a = randomizer.Next(1, 3);
        if( a == 1 )
        {
            //goals.Add(GameObject.Find("goal_4"));
            goals.Add(GameObject.Find("goal_1"));
            goals.Add(GameObject.Find("goal_2"));
            goals.Add(GameObject.Find("goal_3"));
        }
        else
        {
            //goals.Add(GameObject.Find("goal_5"));
            goals.Add(GameObject.Find("goal_6"));
            goals.Add(GameObject.Find("goal_7"));
        }


    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position - getCurrentGoal().transform.position).sqrMagnitude < minDistance) // if current goal is within reach
        {
            nextGoal();
        }
    }
}
