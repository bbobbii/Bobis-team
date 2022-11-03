using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXcontroller : MonoBehaviour
{   //basically I made the script so that I can play only this VFX at once(the other solution that I found
    //on the internet was for every VFX in game 
    //is it only gonna be playe when the function is called)
    [SerializeField] VisualEffect shoot;

    public void PlayVFX()
    {
        shoot.Play();
    }

    public void StopVFX()
    {
        shoot.Stop();
    }
}
