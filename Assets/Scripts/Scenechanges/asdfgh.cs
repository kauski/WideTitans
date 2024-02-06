using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class asdfgh : MonoBehaviour
{
    private void Start()
    {
        enabled = false;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enabled = true; //enables update upon player is on scenechange area.
            Debug.Log("You are on the area now");
        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        enabled = false; //disabes script update upon player collision ends
        Debug.Log("You have left the area");

    }


    void Update()
    {


            SceneManager.LoadScene("wide-titans", LoadSceneMode.Single);
        




    }
}
