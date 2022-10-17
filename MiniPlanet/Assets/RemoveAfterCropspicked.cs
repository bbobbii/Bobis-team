using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAfterCropspicked : MonoBehaviour
{
    public GameObject[] Crops;

    public int picked = 4;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Crop")
        {
            picked--;
            if (picked == 0)
            {
                Destroy(gameObject);
            }

            //for (int i = 0; i < Crops.Length; i++)
            //{
            //   // if(picked <= i) 
            //   // { 
            //    Crops[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            //    //}
            //}
        }
    }
}
