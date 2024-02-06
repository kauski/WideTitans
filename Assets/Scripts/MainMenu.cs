using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// author: Henri Hienonen (last edited 30.3.22) added stat resets jani kauhane 4may22


// https://www.c-sharpcorner.com/article/create-start-menu-scene-using-c-sharp-script-in-unity-3d/

public class MainMenu : MonoBehaviour
{
    private Checkpoint Thischeckpoint;
    public int SetGold;
    public int SetDurability;
    public int SetHealth;
    public int SetFood;
    
    public void PlayGame()
    {
      
        
        Durability.Gold = SetGold;
        Durability.Shipdurability = SetDurability;
        Health.Phealth = SetHealth;
        Food.Shipfood = SetFood;
        Thischeckpoint = GameObject.FindGameObjectWithTag("Checker").GetComponent<Checkpoint>();
        Thischeckpoint.Lastcheckpoint = new Vector2(transform.position.x * 0, transform.position.y * 0);
        Savedays.Daysave = 0;
        Daycounter.Day = 0;
        SceneManager.LoadScene("wide-titans");
    }

    public void Options()
    {
        Debug.Log("Load options");
        
    }

    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}
