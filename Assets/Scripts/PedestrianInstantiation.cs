using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianInstantiation : MonoBehaviour
{
    public GameObject pedestrian;
    public GameObject goal;
    public float goalX;
    public float goalY;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiatePedestrian", 1.0f, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiatePedestrian()
    {
        Instantiate(pedestrian, new Vector2(-10, Random.Range(2f, 10f)), Quaternion.identity);
        //Instantiate(pedestrian, new Vector2(-5, 4), Quaternion.identity);
    }
}
