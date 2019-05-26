using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public List<GameObject> spawnAreas = new List<GameObject>();
    private GameObject objectToSpawnOn;
    public float minRepeatTime;
    public float maxRepeatTime;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiatePedestrian", 1f, Random.Range(minRepeatTime, maxRepeatTime));
    }

    void InstantiatePedestrian()
    {
        objectToSpawnOn = spawnAreas[Random.Range(0, spawnAreas.Count)];

        Vector3 areaSize = objectToSpawnOn.GetComponent<Renderer>().bounds.size;
        Vector3 areaToSpawn = new Vector3(
            Random.Range(objectToSpawnOn.transform.position.x - areaSize.x / 2, objectToSpawnOn.transform.position.x + areaSize.x / 2),
            8f,
            Random.Range(objectToSpawnOn.transform.position.z - areaSize.z / 2, objectToSpawnOn.transform.position.z + areaSize.z / 2));

        GameObject newPed = Instantiate(objectToSpawnOn.GetComponent<SpawnArea>().objectToSpawn, areaToSpawn, Quaternion.identity);
        newPed.GetComponent<MoveToGoal>().initialGoalPosition = objectToSpawnOn.GetComponent<SpawnArea>().initialGoal.transform.position;
    }
}
