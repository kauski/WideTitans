using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//author jani kauhanen 12may22

public class Ending : MonoBehaviour
{
    public Text DaysSurvived;
    
    public GameObject Player;

    public void Endgame()
    {

        Player.SetActive(false);
        DaysSurvived.text = "Days travelled " + Savedays.Daysave.ToString() + ".";
    }  
    

    public void Mainmenu()
    {
        
        Player.SetActive(true);
        SceneManager.LoadScene("MAINMENU");

    }

    public void ExitGame()
    {
        Application.Quit();
    }



}
