using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour
{
    LineRenderer laser;

    float distance = 10f;

    void Start()
    {
        laser = GetComponent<LineRenderer>();
        laser.enabled = false;

    }

    private IEnumerator fireCannon()
    {
        laser.enabled = true;

        while (Input.GetButton("Fire1"))
        {
            Ray ray = new Ray(transform.position, Vector3.forward);
            RaycastHit mine;
            laser.SetPosition(0, ray.origin);

            if (Physics.Raycast(ray, out mine, distance))
            {
                laser.SetPosition(1, mine.point);
                Mining mining = mine.collider.GetComponent<Mining>();

                if(mining != null)
                {
                    mining.DamageDealt(1f);
                }
            }
            else
            {
                 laser.SetPosition(1, ray.direction * distance);
             }


 

            yield return null;


        }
        laser.enabled = false;
    }


   void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StopCoroutine("fireCannon");
            StartCoroutine("fireCannon");
        }
    }

}

