using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

public class PlantedSeeds : MonoBehaviour
    {

        public bool type1 = false;
        public bool type2 = false;
        public bool type3 = false;


        public GameObject[] EmptyPlanter;

        public GameObject[] PlantedPlanter;

    public void Start()
    {
        //EmptyRenderer.GetComponent<Renderer>().materials[0] = textures[0]; 
            //.materials[0].materials = textures[0];
    }


    public void OnCollisionStay(Collision collision)
        {

            if (collision.gameObject.tag == "SeedOne")
            {

                if (type2 == false && type3 == false)
                {
                    type1 = true;
                    DestroySeed();
                    PlantedPlanter[0].GetComponent<MeshRenderer>().enabled = true;
                    //Debug.Log("it did hit");
                }
            }
            else
            if(collision.gameObject.tag == "SeedTwo")
            {

                if (type1 == false && type3 == false)
                {
                    type2 = true;
                    DestroySeed();
                }
            }
            else
            if (collision.gameObject.tag == "SeedThree")
            {

                if (type1 == false && type2 == false)
                {
                    type3 = true;
                    DestroySeed();
                }

        }

            void DestroySeed() 
            {
            Destroy(collision.gameObject);
            }
    }
}
