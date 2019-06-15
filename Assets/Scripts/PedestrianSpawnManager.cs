using System.Collections.Generic;
using UnityEngine;

public class PedestrianSpawnManager : MonoBehaviour {
    public List<GameObject> spawnAreas = new List<GameObject>();
    public GameObject pedestrianPrefab;
    public float minIntervalTime;
    public float maxIntervalTime;
    public float yCoordinate = 8f;
    public List<double> spawnPercentages = new List<double>(); //should get it from Application model based on hour
    public double groupsPerMinute; //number of ppl per minute to be spawned
    public List<double> percentagesPerGroup = new List<double>(); //procent ludzi w 1, 2, 3 i 4 osobowych grupach
    private GameObject spawnArea;

    // Start is called before the first frame update
    void Start()
    {
        loadData();
        Invoke("InstantiatePedestrian", 1f);
    }


    void loadData()
    {
        groupsPerMinute = ApplicationModel.groupsPerMinute[ApplicationModel.sceneNumber];
        spawnPercentages = ApplicationModel.percentagesPerScene[ApplicationModel.sceneNumber];
        percentagesPerGroup = ApplicationModel.percentagePerGroup[ApplicationModel.sceneNumber];
    }

    void InstantiatePedestrian()
    {
        var randomTime = Random.Range((float) (60.0f*0.6/ groupsPerMinute), (float) (60.0f*1.4/ groupsPerMinute));

        double randomNumber = Random.Range(0, 1);

        int count = 1;
        double sum = 0;
        foreach( var cur in percentagesPerGroup)
        {
            sum += cur;
            if (randomNumber <= sum)
                break;

            count++; // count now includes number of people to be spawned at once
        }

        randomNumber = Random.Range(0, 1);
        int spawnAreaNumber = 0;
        sum = 0;
        foreach (var cur in spawnPercentages)
        {
            sum += cur;
            if (randomNumber <= sum)
                break;

            spawnAreaNumber++; // spawnAreaNumber now includes number of spawn area to be spawned in
        }

        int goalNumber = 0;
        sum = 0;
        //foreach( var cur in spawnAreas[spawnAreaNumber].)



        //spawnArea = spawnAreas[Random.Range(0, spawnAreas.Count)];

        //Vector3 areaSize = spawnArea.GetComponent<Renderer>().bounds.size;
        //Vector3 areaToSpawn = new Vector3(
        //    spawnArea.transform.position.x + Random.Range(-areaSize.x / 2, areaSize.x / 2),
        //    yCoordinate,
        //    spawnArea.transform.position.z + Random.Range( - areaSize.z / 2, areaSize.z / 2));

        //GameObject newPed = Instantiate(pedestrianPrefab, areaToSpawn, Quaternion.identity);
        //InitPedestrian(newPed);

        Invoke("InstantiatePedestrian", randomTime);
    }

    void InitPedestrian(GameObject newPed)
    {
        newPed.GetComponent<PedestrianMovement>().initialGoalPosition = spawnArea.GetComponent<SpawnArea>().initialGoal.transform.position;

        // pedestrian can reach every goal! (apart from its spawn position)
        newPed.GetComponent<PedestrianMovement>().destinationObject = spawnArea.GetComponent<SpawnArea>().possibleTargets[Random.Range(0, spawnArea.GetComponent<SpawnArea>().possibleTargets.Count)];
        //do
        //{
        //    newPed.GetComponent<PedestrianMovement>().destinationObject = spawnAreas[Random.Range(0, spawnAreas.Count)]; //spawnArea.GetComponent<SpawnArea>().possibleTargets[Random.Range(0, spawnArea.GetComponent<SpawnArea>().possibleTargets.Count - 1)];
        //} while (
        //    newPed.GetComponent<PedestrianMovement>().destinationObject.transform.position == newPed.GetComponent<PedestrianMovement>().initialGoalPosition
        //);
        newPed.GetComponent<Renderer>().material = spawnArea.GetComponent<SpawnArea>().pedestrianMaterial;
    }
}
