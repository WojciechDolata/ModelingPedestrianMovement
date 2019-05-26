using UnityEngine;

public class CarManager : MonoBehaviour
{
    public Vector3 position;
    public GameObject prefab;

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag(prefab.tag).Length == 0)
        {
            if(Random.Range(1,1000) < 5)
                CarSpawn();
        }
    }

    void CarSpawn()
    {
        switch (prefab.tag)
        {
            case "carA":
                Instantiate(prefab, position, Quaternion.identity * Quaternion.Euler(0.0f, 180.0f, 0.0f));
                break;
            case "carB":
                Instantiate(prefab, position, Quaternion.identity);
                break;
        }
    }
}
