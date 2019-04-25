using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianInstantiation : MonoBehaviour
{
    public GameObject pedestrian;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiatePedestrian", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiatePedestrian()
    {
        Instantiate(pedestrian, new Vector2(-9, Random.Range(-5.0f, 5.0f)), Quaternion.identity);
    }
}
