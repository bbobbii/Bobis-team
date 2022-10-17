using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLetucepick : MonoBehaviour
{
    public GameObject Planter;

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "SeedOne")
        {
            Instantiate(Planter, collision.gameObject.transform);
        }
    }
}
