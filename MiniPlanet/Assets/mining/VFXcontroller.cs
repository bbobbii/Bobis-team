using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXcontroller : MonoBehaviour
{
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
