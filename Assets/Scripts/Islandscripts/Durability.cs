using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//author jani kauhanen 1apr22 //updated 5apr22
public class Durability : MonoBehaviour
{
    //ship repair/take dmg mechanics
    public static int Shipdurability;
    
    static public int Gold; // gold used for ship repairs. Ratio 2 gold to 1 durability. Starting gold 100.
    static public int Repair;
    private void Settings()
    {
        P_repair(gameObject);
    }
    
    public static void P_repair(GameObject rep)
    {

        if (Shipdurability < 90 && Gold > 19)
        {
            Shipdurability = Shipdurability + 10;
            
            Gold = Gold - 20;
            
        }
        else if (Shipdurability == 100)
        {
           
        }
        else if (Gold <= 1 && Shipdurability < 100)
        {
            
        }
        else if (Shipdurability < 100 && Gold > 19)
        {
            Gold = Gold + Shipdurability * 2 - 2 * 100;
            Shipdurability = 100;
                   
        }
        else if (Gold < 20 && Shipdurability < 100 && Gold >= 2 && Gold >= 200 - Shipdurability - Shipdurability)
        {
            if (Gold % 2 == 0)
            {
                Repair = Shipdurability;
                Shipdurability = 100;
                Gold = Gold + Repair * 2 - 2 * 100;
                       
            }
            else
            {
                Gold = Gold - 1;
                Repair = Shipdurability;
                Shipdurability = 100;
                Gold = Gold + Repair * 2 - 2 * 100;
                Gold = Gold + 1;
                           
            }           
        }
        else if (Gold < 20 && Shipdurability < 100 && Gold >= 2 && Gold <= 200 - Shipdurability - Shipdurability)
        {
            if (Gold % 2 == 0)
            {
                Shipdurability = Shipdurability + Gold / 2;
                Gold = 0;
                         
            }
            else
            {
                Gold = Gold - 1;
                Repair = Shipdurability;
                Shipdurability = Shipdurability + Gold / 2;
                Gold = 1;
                            
           }
        }
    }
}