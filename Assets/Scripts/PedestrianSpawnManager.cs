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
    public List<double> goalPercentages = new List<double>();


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

        double randomNumber = Random.Range(0.0f, 1.0f);

        int count = 1;
        double sum = 0;
        foreach( var cur in percentagesPerGroup)
        {
            sum += cur;
            if (randomNumber <= sum)
                break;

            count++; // count now includes number of people to be spawned at once
        }

        randomNumber = Random.Range(0.0f, 1.0f);
        int spawnAreaNumber = 0;
        sum = 0;
        foreach (var cur in spawnPercentages)
        {
            sum += cur;
            if (randomNumber <= sum)
                break;

            spawnAreaNumber++; // spawnAreaNumber now includes number of spawn area to be spawned in
        }

        goalPercentages = ApplicationModel.percentagesPerScenePerGoal[ApplicationModel.sceneNumber][spawnAreaNumber];

        GameObject spawn = spawnAreas[spawnAreaNumber];

        randomNumber = Random.Range(0.0f, 1.0f);
        int goalNumber = 0;
        sum = 0;
        foreach( var cur in goalPercentages)
        {
            sum += cur;
            if (randomNumber <= sum)
                break;

            goalNumber++; // now contains spawn area to end at (goal)
        }

        InitPedestrian(spawn, count, goalNumber);

        Invoke("InstantiatePedestrian", randomTime);
    }

    void InitPedestrian(GameObject spawnArea, int count, int goalNumber)
    {
        var speed = Random.Range(3.0f, 4.0f);
        for(int i = 0; i < count; i++)
        {
            GameObject newPedestrian = Instantiate(pedestrianPrefab, new Vector3(spawnArea.transform.position.x - 0.5f + i*0.2f, spawnArea.transform.position.y, spawnArea.transform.position.z) , Quaternion.identity);
            newPedestrian.GetComponent<PedestrianMovement>().finalGoalPosition = spawnAreas[goalNumber].transform.position;
            newPedestrian.GetComponent<PedestrianMovement>().speed = speed;

            //newPedestrian.GetComponent<PedestrianMovement>().initialGoalPosition = spawnAreas[goalNumber].transform.position;
            newPedestrian.GetComponent<Renderer>().material = spawnArea.GetComponent<SpawnArea>().pedestrianMaterial;
        }
   }

    string spawnAreaName(int spawnAreaNumber) //returns spawn area name
    {
        if (spawnAreaNumber == 0)
            return "ALEJE_LEWA";
        else if (spawnAreaNumber == 1)
            return "ALEJE_PRAWA";
        else if (spawnAreaNumber == 2)
            return "WEJSCIE";
        else if (spawnAreaNumber == 3)
            return "AGH_LEWA";
        else
            return "AGH_PRAWA";
    }

}
