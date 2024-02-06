using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//author jani kauhanen //updated 5may22
public class Food : MonoBehaviour
{
    public static int Shipfood;
    static public bool Begin; //indicator to start/restart game to adjust stats.
    static public int Amount;
    private static Food Datasave;
    private void Awake()
    {
        if (Datasave == null)
        {
            Datasave = this;
            DontDestroyOnLoad(Datasave);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        if (Shipfood == 0 && Durability.Gold == 0 && Durability.Shipdurability == 0 && Health.Phealth == 0)

        Shipfood = 20;
        Durability.Gold = 15;
        Durability.Shipdurability = 15;
        Health.Phealth = 5;
        Begin = false;
        Daycounter.Day = 0;
    }
    public static void P_food(GameObject fod)
    {
        if (Shipfood < 90 && Durability.Gold > 19)
        {
            Shipfood = Shipfood + 10;
           
            Durability.Gold = Durability.Gold - 20;
            
        }
        else if (Shipfood == 100)
        {
           
            
        }
        else if (Durability.Gold <= 1 && Shipfood < 100)
        {
           
        }
        else if (Shipfood < 100 && Durability.Gold > 19)
        {
            Durability.Gold = Durability.Gold + Shipfood * 2 - 2 * 100;
            Shipfood = 100;
           
        }
        else if (Durability.Gold < 20 && Shipfood < 100 && Durability.Gold >= 2 && Durability.Gold >= 200 - Shipfood - Shipfood)
        {
            if (Durability.Gold % 2 == 0)
            {
                Amount = Shipfood;
                Shipfood = 100;
                Durability.Gold = Durability.Gold + Amount * 2 - 2 * 100;
               
            }
            else
            {
                Durability.Gold = Durability.Gold - 1;
                Amount = Shipfood;
                Shipfood = 100;
                Durability.Gold = Durability.Gold + Amount * 2 - 2 * 100;
                Durability.Gold = Durability.Gold + 1;
               
            }
        }
        else if (Durability.Gold < 20 && Shipfood < 100 && Durability.Gold >= 2 && Durability.Gold <= 200 - Shipfood - Shipfood)
        {
            if (Durability.Gold % 2 == 0)
            {
                Shipfood = Shipfood + Durability.Gold / 2;
                Durability.Gold = 0;
               
            }
            else
            {
                Durability.Gold = Durability.Gold - 1;
                Amount = Shipfood;
                Shipfood = Shipfood + Durability.Gold / 2;
                Durability.Gold = 1;
             
            }
        }
    }
}