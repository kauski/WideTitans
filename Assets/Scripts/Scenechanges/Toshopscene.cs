using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//author jani kauhanen
//unused, might remove the whole script Jani Kauhanen 5may22
public class Toshopscene : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           
            SceneManager.LoadScene("wide-titans", LoadSceneMode.Single);
        }
    }
}