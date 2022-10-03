    using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Xml;
using UnityEngine;

public class SeedPlanter : MonoBehaviour
{
    [SerializeField] GameObject Seed;
    [SerializeField] GameObject Planter;
    [SerializeField] GameObject PlantedSeed;
    //[SerializeField] Transform dirt;
    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.tag == "Planter")
        {

            Destroy(Seed);
            Planter.SetActive(false);
            PlantedSeed.SetActive(true);

            //Instantiate(PlantedSeed, dirt.position, dirt.rotation);
        }
    }
}
