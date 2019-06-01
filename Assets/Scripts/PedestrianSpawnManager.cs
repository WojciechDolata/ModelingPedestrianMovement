using System.Collections.Generic;
using UnityEngine;

public class PedestrianSpawnManager : MonoBehaviour
{
    public List<GameObject> spawnAreas = new List<GameObject>();
    public GameObject pedestrianPrefab;
    public float minIntervalTime;
    public float maxIntervalTime;
    public float yCoordinate = 8f;

    private GameObject spawnArea;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("InstantiatePedestrian", 1f);
    }

    void InstantiatePedestrian()
    {
        float randomTime = Random.Range(minIntervalTime, maxIntervalTime);

        spawnArea = spawnAreas[Random.Range(0, spawnAreas.Count)];

        Vector3 areaSize = spawnArea.GetComponent<Renderer>().bounds.size;
        Vector3 areaToSpawn = new Vector3(
            spawnArea.transform.position.x + Random.Range(-areaSize.x / 2, areaSize.x / 2),
            yCoordinate,
            spawnArea.transform.position.z + Random.Range( - areaSize.z / 2, areaSize.z / 2));

        GameObject newPed = Instantiate(pedestrianPrefab, areaToSpawn, Quaternion.identity);
        InitPedestrian(newPed);

        Invoke("InstantiatePedestrian", randomTime);
    }

    void InitPedestrian(GameObject newPed)
    {
        newPed.GetComponent<PedestrianMovement>().initialGoalPosition = spawnArea.GetComponent<SpawnArea>().initialGoal.transform.position;

        // pedestrian can reach every goal! (apart from its spawn position)
        do
        {
            newPed.GetComponent<PedestrianMovement>().destinationObject = spawnAreas[Random.Range(0, spawnAreas.Count)]; //spawnArea.GetComponent<SpawnArea>().possibleTargets[Random.Range(0, spawnArea.GetComponent<SpawnArea>().possibleTargets.Count - 1)];
        } while (
            newPed.GetComponent<PedestrianMovement>().destinationObject.transform.position == newPed.GetComponent<PedestrianMovement>().initialGoalPosition
        );
        newPed.GetComponent<Renderer>().material = spawnArea.GetComponent<SpawnArea>().pedestrianMaterial;
    }
}
