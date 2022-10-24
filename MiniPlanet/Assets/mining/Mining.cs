using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mining : MonoBehaviour
{
    
    public float health = 50f;
    //i will let it public for now, different minerals will have different health
    public void TakeDamage(float amount)
    //im creating the take damage value, the mining will work like this(the iron will have 50 health point and it will take damage over time from the laser)
    {
        health -= amount;
        if (health <= 0f)
        {   //if the health is below 0 the rock will explode and the player will be able to collet materials 
            Explode();
            
        }

    }

    void Explode()
    {
        Destroy(gameObject);
    }

}
