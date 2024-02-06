using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//author jani kauhanen 11may22
//new player tips - island scene.
public class Playertips : MonoBehaviour
{
    
    public GameObject Tips;
    bool Tipactive;
    
    public bool TipDone;
    void Start()
    {
        Tips.SetActive(false);
        Tipactive = false;
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player" && TipDone == false)
        {
            if (TipDone == false)
            {
                Tips.SetActive(true);
                Tipactive = true;
               
               
            }

        }

        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Tips.SetActive(false);
        Tipactive = false;
    }

    private void Update()
    {
        if (Tipactive == true && Input.GetKeyDown(KeyCode.E))
         {
            TipDone = true;
            Tips.SetActive(false);
            Tipactive = false;
            
            
           

        }
    }

}
