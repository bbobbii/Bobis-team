using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


    public class PlantedSeeds : MonoBehaviour
    {

        public bool type1 = false;
        public bool type2 = false;
        public bool type3 = false;

    public void OnCollisionStay(Collision collision)
        {
            Debug.Log("it did hit");
            if (collision.gameObject.tag == "SeedOne")
            {
                type1 = true;

                type2 = false;

                type3 = false;
            }
            else
            if(collision.gameObject.tag == "SeedTwo")
            {
                type2 = true;

                type1 = false;

                type3 = false;
            }
            else
                 if (collision.gameObject.tag == "SeedThree")
            {
            type3 = true;

            type2 = false;

            type1 = false;
        }
    }
}
