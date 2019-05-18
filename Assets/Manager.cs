using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject sampleObject;
    public float repeatTime;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiatePedestrian", 1f, repeatTime);
    }

    void InstantiatePedestrian()
    {
        Vector3 areaSize = objectToSpawn.GetComponent<Renderer>().bounds.size;
        Vector3 areaToSpawn = new Vector3(
            Random.Range(objectToSpawn.transform.position.x - areaSize.x / 2, objectToSpawn.transform.position.x + areaSize.x / 2),
            8f,
            Random.Range(objectToSpawn.transform.position.z - areaSize.z / 2, objectToSpawn.transform.position.z + areaSize.z / 2));
        Instantiate(sampleObject, areaToSpawn, Quaternion.identity);
    }
}
