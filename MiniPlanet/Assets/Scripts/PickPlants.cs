using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickPlants : MonoBehaviour, IInteractable
{
    public GameObject PlantedPlanter;
    public GameObject UnplantedPlanter;


    public string GetDescription()
    {
        return "Pick Plants";
    }

    public void Interact()
    {
        PlantedPlanter.SetActive(false);
        UnplantedPlanter.SetActive(true);
    }

}
