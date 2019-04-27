using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianInstantiation : MonoBehaviour
{
    public GameObject pedestrian;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiatePedestrian", 1.0f, 0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiatePedestrian()
    {
        Instantiate(pedestrian, new Vector2(0, Random.Range(0.0f, 10.0f)), Quaternion.identity);
    }
}
