using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//author jani kauhanen
public class Displayfood : MonoBehaviour
{
    private int __food;
    public Text _food;
    void Start()
    {
        _food = transform.GetComponent<Text>();
        __food = Food.Shipfood;
        if (__food == 0)
        {
            Updatefood();
        }
        _food.text = "Food " + __food.ToString();
    }
    public void Updatefood()
    {
        __food = Food.Shipfood;
        _food.text = "Food " + __food.ToString();
        
    }
}