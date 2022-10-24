using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pewpew : MonoBehaviour
{
    public float damage = 10f;
    public float range = 2f;
    
    public Camera Cam;
    
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            VFXcontroller vFXcontroller = GetComponent<VFXcontroller>();
            vFXcontroller.PlayVFX();
            Shoot();

        }
      

    }

    // Update is called once per frame
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 10);
    }
}
