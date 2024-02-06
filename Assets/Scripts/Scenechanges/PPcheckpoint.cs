using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
//author jani kauhanen 20apr22
public class PPcheckpoint : MonoBehaviour
{
    private Checkpoint Playerpos;
   void Start()
    {

        Playerpos = GameObject.FindGameObjectWithTag("Checker").GetComponent<Checkpoint>();
        transform.position = Playerpos.Lastcheckpoint;
    }
    }