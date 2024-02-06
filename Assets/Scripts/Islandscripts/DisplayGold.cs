using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
//author jani kauhanen
public class DisplayGold : MonoBehaviour
{
  private int __gold;
  public Text _Gold;
    public void Start()
    {
        __gold = Durability.Gold;
        _Gold = transform.GetComponent<Text>();
        __gold = Durability.Gold;
        if (__gold == 0)
        {
            UpdateGold();
        }

        _Gold.text = "Gold " + __gold.ToString();

    }
   public void UpdateGold()
    {

        
        __gold = Durability.Gold;
        _Gold.text = "Gold " + __gold.ToString();
    }
}