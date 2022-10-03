using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringPlants : MonoBehaviour
{
    [SerializeField] GameObject PlantedSeed;
    [SerializeField] GameObject WateredPlants;
    //[SerializeField] Transform dirt;
    [SerializeField] ParticleSystem particles;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("WHOOO!!");
        StartCoroutine(GrowthDelay());
        
    }

    IEnumerator GrowthDelay()
    {
        yield return new WaitForSeconds(3f);
        PlantedSeed.SetActive(false);
        WateredPlants.SetActive(true);

    }
}