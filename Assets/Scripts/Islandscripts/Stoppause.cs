using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//author jani kauhanen
//to prevent bug occuring on timescale 0
public class Stoppause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
