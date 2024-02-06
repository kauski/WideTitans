using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//author jani kauhanen 5may22
public class Savedays : MonoBehaviour
{
    public static int Daysave;
    private static Savedays Datasave1;
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
