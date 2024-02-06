using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//author jani kauhanen
public class Shopenter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shopkeeper" && Activateshop.area == false)
        {
            Activateshop.area = true;
        }
        if (collision.gameObject.tag == "Shop" && Activateshop.area == true)
        {
            Activateshop.area = false;
        }
    }
}