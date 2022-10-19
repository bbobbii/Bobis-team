//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Sends UnityEvents for basic hand interactions
//
//=============================================================================

using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Security.Principal;

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


        public GameObject FadeScreen;
        public bool fadeOnStart = true;
        public float fadeDuration = 2;
        public Color fadeColor;
        private Renderer rend;


        public void Start()
        {
            rend = FadeScreen.GetComponent<Renderer>();
            if (fadeOnStart)
            FadeIn();
        }

        public void Update()
        {
            if (clickInteract.stateDown && isHover == true)
            {
                StartCoroutine(FadeInandOut());
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


        public void FadeIn()
        {
            Fade(1, 0);
        }
        public void FadeOut()
        {
            Fade(0, 1);
        }


        public void Fade(float alphaIn, float alphaOut)
        {
            StartCoroutine (FadeRoutine(alphaIn, alphaOut));
        }


        public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
        {
            float timer = 0;
            while(timer <= fadeDuration)
            {
                Color newColor = fadeColor;
                newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);

                rend.material.SetColor("_BaseColor", newColor);

                timer += Time.deltaTime;
                yield return null;
            }
            Color newColor2 = fadeColor;
            newColor2.a = alphaOut;
            rend.material.SetColor("_BaseColor", newColor2);
        }

        public IEnumerator FadeInandOut()
        {
            FadeOut();
            yield return new WaitForSeconds(4);
            FadeIn();
        }
    }
}

