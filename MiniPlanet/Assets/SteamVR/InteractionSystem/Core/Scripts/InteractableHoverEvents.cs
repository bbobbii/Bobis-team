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
	[RequireComponent( typeof( Interactable ) )]
	public class InteractableHoverEvents : MonoBehaviour
	{
		public SteamVR_Action_Boolean clickInteract;
		public MeshFilter garden;
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


		public void Update()
		{
			if (clickInteract.stateDown && isHover == true)
			{
				garden.mesh = Garden[0];
                onAttachedToHand.Invoke();

                if (isGrown == true && waterd == true)
                {
                    garden.mesh = Garden[1];
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
		private void OnAttachedToHand( Hand hand )
		{
			onAttachedToHand.Invoke();
		}


		//-------------------------------------------------
		private void OnDetachedFromHand( Hand hand )
		{
			onDetachedFromHand.Invoke();
		}
	}
}
