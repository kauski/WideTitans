using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//author jani kauhanen 5may22
public class Deathscreen : MonoBehaviour
{
    public Text DaysSurvived;
    public GameObject Player;
    public void Death()
    {
        Player.SetActive(false);
        gameObject.SetActive(true);
        DaysSurvived.text = "You survived " + Savedays.Daysave.ToString() + " Days";

    }

    public void Mainmenu()
    {
        Player.SetActive(true);
        SceneManager.LoadScene("MAINMENU");
    }
    public void Exitgame()
    {
        Application.Quit();
    }
  

}


