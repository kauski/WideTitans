using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Diisplayminidura : MonoBehaviour
{
   

    private int __Durability;
    public Text _Durability;
    public void Start()
    {
        _Durability = transform.GetComponent<Text>();
        __Durability = Durability.Shipdurability;
        if (__Durability == 0)
        {
            Durability.Shipdurability = __Durability;
        }
        _Durability.text = "Durability: " + __Durability.ToString();
    }
    public void UpdateDurability()
    {
        __Durability = Durability.Shipdurability;
        _Durability.text = "Durability: " + __Durability.ToString();
        Debug.Log($"{__Durability}");
       

    }
}