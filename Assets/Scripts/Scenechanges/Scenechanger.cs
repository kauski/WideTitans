using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//scenechanger
//author jani kauhanen
public class Scenechanger : MonoBehaviour
{
    public GameObject Textbackground;
    public GameObject Enter;
    private void Start()
    {
        enabled = false;
        Enter.SetActive(false);
        Textbackground.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Enter.SetActive(true);
            Textbackground.SetActive(true);
            enabled = true; //enables update upon player is on scenechange area.
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        enabled = false; //disabes script update upon player collision ends
     
        Textbackground.SetActive(false);
        Enter.SetActive(false);
    }
    void Update()
        {  
    if (Input.GetKeyDown(KeyCode.E))
        {
            Textbackground.SetActive(false);
            Enter.SetActive(false);
           
            SceneManager.LoadScene("OVERWORLD", LoadSceneMode.Single);
}
    }
}