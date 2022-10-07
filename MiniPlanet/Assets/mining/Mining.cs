using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : MonoBehaviour
{

    public float health;
    private float currentHealth = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DamageDealt(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }

    }
}
