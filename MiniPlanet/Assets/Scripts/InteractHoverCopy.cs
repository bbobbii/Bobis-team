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
        public MeshFilter[] garden;
        //public Mesh growingGarden;
        //public Mesh moreGrown;
        public Mesh[] Garden;


        public UnityEvent onHandHoverBegin;
        public UnityEvent onHandHoverEnd;
        public UnityEvent onAttachedToHand;
        public UnityEvent onDetachedFromHand;


        public bool isHover = false;

        public bool isGrown = false;

        public bool waterd = true;


        //public void Start()
        //{
        //	PlantedSeeds gardennn = garden[0].GetComponent<PlantedSeeds>();
        //}

        public void Update()
        {
            if (clickInteract.stateDown && isHover == true)
            {

                //change the first garden into something else depending on a component on that garden
                if (garden[0].GetComponent<PlantedSeeds>().type1 == true)
                {
                    garden[0].mesh = Garden[0];
                    //onAttachedToHand.Invoke();
                }
                else
                if(garden[0].GetComponent<PlantedSeeds>().type2 == true)
                {
                    garden[0].mesh = Garden[1];
                }

                //change the second garden into something else depending on a component on that garden
                if (garden[1].GetComponent<BoxCollider>() == true)
                {
                    garden[1].mesh = Garden[0];
                }

                if (isGrown == true && waterd == true)
                {
                    garden[0].mesh = Garden[1];
                }
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

