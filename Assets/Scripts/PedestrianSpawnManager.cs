using System.Collections.Generic;
using UnityEngine;

public class PedestrianSpawnManager : MonoBehaviour {

    public List<GameObject> spawnAreas = new List<GameObject>(); // Lista naszych SpawnAreas
    public GameObject pedestrianPrefab;
    public List<double> spawnPercentages = new List<double>(); // Rozkład prawdopodobieństwa na spawn w danym SpawnArea
    public double groupsPerMinute; // Ilość grup 1, 2,3 lub 4 osobowych na minutę
    public List<double> percentagesPerGroup = new List<double>(); // Rozkład prawdopodobieństwa na 1, 2, 3 i 4 osobowe grupy
    private GameObject spawnArea;
    public List<double> goalPercentages = new List<double>(); // Rozkład prawdopodobieństwa na punkty docelowe, czyli Quo Vadis


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
        // czas przed kolejnym spawnem
        var randomTime = Random.Range((float) (60.0f*0.6/ groupsPerMinute), (float) (60.0f*1.4/ groupsPerMinute));

        /*
         Liczy ile osób powinno być utworzonych w danej chwili (int count)
            */
        double randomNumber = Random.Range(0.0f, 1.0f);
        int count = 1;
        double sum = 0;
        foreach( var cur in percentagesPerGroup)
        {
            sum += cur;
            if (randomNumber <= sum)
                break;

            count++;
        }

        /*
         Liczy w którym SpawnArea powinni pojawić się piesi
            */
        randomNumber = Random.Range(0.0f, 1.0f);
        int spawnAreaNumber = 0;
        sum = 0;
        foreach (var cur in spawnPercentages)
        {
            sum += cur;
            if (randomNumber <= sum)
                break;

            spawnAreaNumber++;
        }

        goalPercentages = ApplicationModel.percentagesPerScenePerGoal[ApplicationModel.sceneNumber][spawnAreaNumber];

        GameObject spawn = spawnAreas[spawnAreaNumber];


        /*
         Liczy w którym miejscu powinien być ich punkt docelowy
            */
        randomNumber = Random.Range(0.0f, 1.0f);
        int goalNumber = 0;
        sum = 0;
        foreach( var cur in goalPercentages)
        {
            sum += cur;
            if (randomNumber <= sum)
                break;

            goalNumber++;
        }

        InitPedestrian(spawn, count, goalNumber);

        Invoke("InstantiatePedestrian", randomTime);
    }

    /*
         Inicjalizacja pieszych w spawnArea, o liczebności count i punkcie docelowym goalNumber, który odzwierciedla SpawnArea
            */
    void InitPedestrian(GameObject spawnArea, int count, int goalNumber)
    {
        var speed = Random.Range(3.0f, 4.0f);
        for(int i = 0; i < count; i++)
        {
            GameObject newPedestrian = Instantiate(pedestrianPrefab, new Vector3(spawnArea.transform.position.x - 0.5f + i*0.2f, spawnArea.transform.position.y, spawnArea.transform.position.z) , Quaternion.identity);
            newPedestrian.GetComponent<PedestrianMovement>().finalGoalPosition = spawnAreas[goalNumber].transform.position;
            newPedestrian.GetComponent<PedestrianMovement>().speed = speed;
            newPedestrian.GetComponent<Renderer>().material = spawnArea.GetComponent<SpawnArea>().pedestrianMaterial;
        }
    }
}
