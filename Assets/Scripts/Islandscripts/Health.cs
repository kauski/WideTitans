using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//author jani kauhanen
//to adjust start health, go to Food.cs script.
public class Health : MonoBehaviour
{
    public static int Phealth;
    private static Health Datasave1;
    private void Awake()
    {
        if (Datasave1 == null)
        {
            Datasave1 = this;
            DontDestroyOnLoad(Datasave1);
        }
        else
        {
            Destroy(gameObject);
        }
    } 
    }