using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endscreen : MonoBehaviour
{
    public GameObject Endgame;
    public Ending Update;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "End") 
        {
            Endgame.SetActive(true);
            Update.Endgame();
        }

    }






}
