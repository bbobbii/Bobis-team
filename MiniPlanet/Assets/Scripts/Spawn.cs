using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject objectToSpawn;
    //public Vector3 origin = Vector3.zero;
   // public float radius = 10;
    public float space = 2;

    // Start is called before the first frame update
    void Start()
    {

       // Vector3 randomPosition = origin + Random.insideUnitSphere * radius;

        for (int i = 0; i < 10; i++)
        {


            Vector3 randomSpawnPosition = new Vector3(Random.Range(0, 100), 2, Random.Range(0, 100));
            Instantiate(objectToSpawn, randomSpawnPosition, Quaternion.identity);
            

        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    /*void SpawnObject()
    {
        GameObject newObject = Instantiate(objectToSpawn, transform.position,Quaternion.identity);


    }*/
}
