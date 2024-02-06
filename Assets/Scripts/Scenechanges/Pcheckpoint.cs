using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//author jani kauhanen 20apr22
public class Pcheckpoint : MonoBehaviour
{
    private Checkpoint Thischeckpoint;
    private int Checkpoint; //Transform over the island for next scene.
     void Start()
    {
        Checkpoint = 10;
        Thischeckpoint = GameObject.FindGameObjectWithTag("Checker").GetComponent<Checkpoint>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Thischeckpoint.Lastcheckpoint = new Vector2(transform.position.x + Checkpoint, transform.position.y * 0);
            SceneManager.LoadScene("wide-titans", LoadSceneMode.Single);
        }
    }
}