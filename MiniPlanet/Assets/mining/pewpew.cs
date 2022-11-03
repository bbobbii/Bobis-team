using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pewpew : MonoBehaviour
{   //the variables are public for now because we have to test it with the VR as well
    public float damage = 10f;
    public float range = 2f;
    public Camera Cam;
    
    void Update()
    {   //here is the shooting mechanic so that when button "Fire1" is press it will shoot the laser
        //or the VFX will be played in this case
        if (Input.GetButtonDown("Fire1"))
        {
            VFXcontroller vFXcontroller = GetComponent<VFXcontroller>();
            vFXcontroller.PlayVFX();
            Shoot();
        }
    }

    // shoot funtion basically is the shooting mechanic, it uses the camera position so that it will be projected forward
    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(Cam.transform.position,Cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Mining mining = hit.transform.GetComponent<Mining>();
            if (mining != null)
            {
                mining.TakeDamage(damage);
            }
        }
    }
    // I had some problems with the rotation of the laser, therefore I was testing with the Gizmo(it was a hierachy problem)
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(Cam.transform.position, Cam.transform.position + Cam.transform.forward * 10);
    }
}
