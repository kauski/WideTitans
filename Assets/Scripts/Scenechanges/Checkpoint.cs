using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//author jani kauhanen 20apr22
public class Checkpoint : MonoBehaviour
{
    public Vector2 Lastcheckpoint;
    private static Checkpoint Currentpoint;
    private void Awake()
    {
        if(Currentpoint == null)
        {
            Currentpoint = this;
            DontDestroyOnLoad(Currentpoint);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}