using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    public GameObject self;
    public GameObject initialGoal;
    public Material pedestrianMaterial;
    public List<GameObject> possibleTargets = new List<GameObject>();
    public List<double> goalPercentages = new List<double>();

    // Start is called before the first frame update
    void Start()
    {
        loadGoalPercentages();
    }

    /*
     Mapuje nazwę celu na id, przydaje sie przy braniu wartosci z listy rozkladu prawdopodobienstwa
         */
    int goalNameMapper()
    {
        if (this.initialGoal.name == "ALEJE_LEWA")
            return 0;
        else if (this.initialGoal.name == "ALEJE_PRAWA")
            return 1;
        else if (this.initialGoal.name == "WEJSCIE")
            return 2;
        else if (this.initialGoal.name == "AGH_LEWA")
            return 3;
        else
            return 4;
    }

    void loadGoalPercentages()
    {
        this.goalPercentages = ApplicationModel.percentagesPerScenePerGoal[ApplicationModel.sceneNumber][goalNameMapper()];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
