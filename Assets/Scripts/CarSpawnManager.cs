﻿using System.Collections.Generic;
using UnityEngine;

public class CarSpawnManager : MonoBehaviour
{
    public List<GameObject> spawnPoints = new List<GameObject>();
    public float minIntervalTime;
    public float maxIntervalTime;
    public GameObject carPrefab;

    private GameObject spawnPoint;

    void Start()
    {
        InvokeRepeating("InstantiateCar", 5f, Random.Range(minIntervalTime, maxIntervalTime));
    }

    void InstantiateCar()
    {
        spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
        GameObject newCar = Instantiate(carPrefab, spawnPoint.transform.position, Quaternion.identity * Quaternion.Euler(0.0f, spawnPoint.GetComponent<SpawnPoint>().carRotation, 0.0f));
        InitCar(newCar);
    }

    void InitCar(GameObject newCar)
    {
        newCar.GetComponent<CarMovement>().goalPosition = spawnPoint.GetComponent<SpawnPoint>().target.transform.position;
    }
}