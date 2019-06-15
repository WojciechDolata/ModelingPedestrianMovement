using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationModel : MonoBehaviour
{

    public static int numOfDay = 0;
    public static string hhmmss = "00:00:00";
    /* 
     tutaj bedzie scene number, odpowiednio 0,1,2,3,4 dla 8:00, 10:30, 15:00, 17:00, 20:00
         */
    public static int sceneNumber = -1;

    /*
     Liczba ludzi na minute
         */
    public static List<double> groupsPerMinute = new List<double> { 3, 6, 5.214, 3.571, 1.615};

    /*
     szanse na liczebność grupy
         */
    public static List<List<double>> percentagePerGroup = new List<List<double>> {
        new List<double> { 0.76, 0.12, 0.05, 0.07},
        new List<double> { 0.833, 0.125, 0.014, 0.028},
        new List<double> { 0.71, 0.19, 0.1, 0 },
        new List<double> { 0.8, 0.14, 0.06, 0},
        new List<double> { 0.76, 0.24, 0, 0 }
    };

    /* 
     na kazda scene z 5 przypada po 5 procentow dla kazdego z 5 spawn area
     w kolejnosci: 
        Aleje Lewe
        Aleje Praw
        Wejscie (pod lacznikiem)
        AGH Lewe
        AGH Prawe
         */
    public static List<List<double>> percentagesPerScene = new List<List<double>> {
        new List<double> { 0.25, 0.05, 0, 0.383, 0.317},
        new List<double> { 0.26, 0.19, 0.11, 0.21, 0.23},
        new List<double> { 0.36, 0.15, 0.1, 0.23, 0.16 },
        new List<double> { 0.24, 0.14, 0, 0.37, 0.25},
        new List<double> { 0.31, 0.08, 0, 0.38, 0.23 }
    };

    /* 
     na kazda scene z 5 przypada po 5 list z procentami dla kazdego z 5 celow dla kazdego z 5 spawn area
     w kolejnosci: 
        Aleje Lewe
        Aleje Praw
        Wejscie (pod lacznikiem)
        AGH Lewe
        AGH Prawe
         */
    public static List<List<List<double>>> percentagesPerScenePerGoal = new List<List<List<double>>> {
        new List<List<double>> {
            new List<double> { 0, 0, 0, 0.9, 0.1 },
            new List<double> { 0, 0, 0, 0.1, 0.9 },
            new List<double> { 0, 0, 0, 0, 1 },
            new List<double> { 0.9, 0.1, 0, 0, 0 },
            new List<double> { 0.1, 0.9, 0, 0, 0 }
        },
        new List<List<double>> {
            new List<double> { 0, 0, 0, 0.9, 0.1 },
            new List<double> { 0, 0, 0.7, 0.05, 0.25 },
            new List<double> { 0.26, 0.24, 0, 0.21, 0.29 },
            new List<double> { 0.9, 0.1, 0, 0, 0 },
            new List<double> { 0.05, 0.25, 0.7, 0, 0 }
        },
        new List<List<double>> {
            new List<double> { 0, 0, 0, 0.9, 0.1 },
            new List<double> { 0, 0, 0.6, 0.05, 0.35 },
            new List<double> { 0.36, 0.2, 0, 0.22, 0.22 },
            new List<double> { 0.9, 0.1, 0, 0, 0 },
            new List<double> { 0.05, 0.35, 0.6, 0, 0 }
        },
        new List<List<double>> {
            new List<double> { 0, 0, 0, 0.9, 0.1 },
            new List<double> { 0, 0, 0, 0.1, 0.9 },
            new List<double> { 0, 0, 0, 0, 1 },
            new List<double> { 0.9, 0.1, 0, 0, 0 },
            new List<double> { 0.1, 0.9, 0, 0, 0 }
        },
        new List<List<double>> {
            new List<double> { 0, 0, 0, 0.9, 0.1 },
            new List<double> { 0, 0, 0, 0.1, 0.9 },
            new List<double> { 0, 0, 0, 0, 1 },
            new List<double> { 0.9, 0.1, 0, 0, 0 },
            new List<double> { 0.1, 0.9, 0, 0, 0 }

        },
    };


}
