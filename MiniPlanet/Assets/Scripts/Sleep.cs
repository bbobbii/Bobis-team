using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sleep : MonoBehaviour, IInteractable
{
    public GameObject ThePlayer;
    public GameObject Fadescreen;

    public GameObject PlantedSeed;
    public GameObject NextStage;

    public string GetDescription()
    {
        return "Go to sleep";
    }

    public void Interact()
    {
        ThePlayer.GetComponent<FirstPersonMovement>().enabled = false;
        StartCoroutine(ScenePlayer());

        if (GameObject.FindGameObjectsWithTag("PlantedCrop").Length == 1)
        {
            PlantedSeed.SetActive(false);
            NextStage.SetActive(true);
        }

    }

    IEnumerator ScenePlayer()
    {
        Fadescreen.SetActive(true);
        yield return new WaitForSeconds(3f);
        Fadescreen.SetActive(false);
        ThePlayer.GetComponent<FirstPersonMovement>().enabled = true;
    }
}
