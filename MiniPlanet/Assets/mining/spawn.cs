using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Vector3 origin = Vector3.zero;
    public float radius = 10;
    public float space = 2;

    // Start is called before the first frame update
    void Start()
    {

        Vector3 randomPosition = origin + Random.insideUnitSphere * radius;

        for (int i = 0; i < 10; i++)
        {
            Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
            randomPosition.x += Random.Range(-10, 10);
            randomPosition.z += Random.Range(-20, 20);

        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    void SpawnObject()
    {
        GameObject newObject = Instantiate(objectToSpawn);


    }
}