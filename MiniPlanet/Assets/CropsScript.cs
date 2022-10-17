using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropsScript : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Planter")
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
