//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Sends UnityEvents for basic hand interactions
//
//=============================================================================

using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
    //-------------------------------------------------------------------------
    [RequireComponent(typeof(Interactable))]
    public class InteractHoverCopy : MonoBehaviour
    {
        public SteamVR_Action_Boolean clickInteract;

        public GameObject[] PlantedPlanter;
        public GameObject[] GrownPlanter;
        public Transform[] PlanterSpots;


        public UnityEvent onHandHoverBegin;
        public UnityEvent onHandHoverEnd;
        public UnityEvent onAttachedToHand;
        public UnityEvent onDetachedFromHand;


        public bool isHover = false;

        public bool isGrown = false;

        public bool waterd = true;


        public void Update()
        {
            if (clickInteract.stateDown && isHover == true)
            {

                //change the first garden into something else depending on a component on that garden
                if (PlantedPlanter[0].GetComponent<PlantedSeeds>().type1 == true)
                {
                    PlantedPlanter[0].GetComponent<MeshRenderer>().enabled = false;
                    Instantiate(GrownPlanter[0], PlanterSpots[0]);
                    PlantedPlanter[0].GetComponent<PlantedSeeds>().type1 = false;
                    //GrownPlanter[0].SetActive(true); //!!!!! change with instantiate prefab with pickupable crop!!!!!
                    //onAttachedToHand.Invoke();
                }
                //else
                //if(garden[0].GetComponent<PlantedSeeds>().type2 == true)
                //{
                //    garden[0].mesh = Garden[1];
                //}
                //else
                //if (garden[0].GetComponent<PlantedSeeds>().type3 == true)
                //{
                //    garden[0].mesh = Garden[2];
                //}


                ////change the second garden into something else depending on a component on that garden
                //if (garden[1].GetComponent<PlantedSeeds>().type1 == true)
                //{
                //    garden[1].mesh = Garden[0];
                //}
                //else
                //if (garden[1].GetComponent<PlantedSeeds>().type2 == true)
                //{
                //    garden[1].mesh = Garden[1];
                //}
                //else
                //if (garden[1].GetComponent<PlantedSeeds>().type3 == true)
                //{
                //    garden[1].mesh = Garden[2];
                //}



                //if (isGrown == true && waterd == true)
                //{
                //    garden[0].mesh = Garden[1];
                //}
            }
        }

        //-------------------------------------------------
        private void OnHandHoverBegin()
        {
            isHover = true;
            onHandHoverBegin.Invoke();
        }


        //-------------------------------------------------
        private void OnHandHoverEnd()
        {
            isHover = false;
            onHandHoverEnd.Invoke();
        }


        //-------------------------------------------------
        private void OnAttachedToHand(Hand hand)
        {
            onAttachedToHand.Invoke();
        }


        //-------------------------------------------------
        private void OnDetachedFromHand(Hand hand)
        {
            onDetachedFromHand.Invoke();
        }
    }
}
