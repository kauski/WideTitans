using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playertip : MonoBehaviour
{
    public GameObject Playertips;



    private void Start()
    {
        Playertips.SetActive(true);
    }


    void Update()
{


        if (Input.GetKeyDown(KeyCode.D))
        {
            Playertips.SetActive(false);
        }
    }
}

