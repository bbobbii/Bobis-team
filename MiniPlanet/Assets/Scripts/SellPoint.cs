using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SellPoint : MonoBehaviour
{
    public int moneyAmount;

    public GameObject MoneyText;

    private void Start()
    { 
        moneyAmount = PlayerPrefs.GetInt("money");
    }

    void Update()
    {
        TextMesh TextObject = MoneyText.GetComponent<TextMesh>();
        TextObject.text = "" + moneyAmount;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Crop")
        {
            moneyAmount += 1;
            Destroy(collision.gameObject);
        }
    }
}
