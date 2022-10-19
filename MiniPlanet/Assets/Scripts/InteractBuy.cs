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
    public class InteractBuy : MonoBehaviour
    {
        public SteamVR_Action_Boolean clickInteract;

        public GameObject SellSpot;
        public Transform SpawnBuypoint;

        public GameObject[] SeedforBuy;

        public UnityEvent onHandHoverBegin;
        public UnityEvent onHandHoverEnd;
        public UnityEvent onAttachedToHand;
        public UnityEvent onDetachedFromHand;


        public bool isHover = false;

        public void Update()
        {
            if (clickInteract.stateDown && isHover == true)
            {
                if (SellSpot.GetComponent<SellPoint>().moneyAmount >= 2)
                {
                    SellSpot.GetComponent<SellPoint>().moneyAmount -= 2;

                    Instantiate(SeedforBuy[0], SpawnBuypoint);
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

