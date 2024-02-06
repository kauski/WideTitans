using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//https://www.youtube.com/watch?v=JivuXdrIHK0

public class PauseMenu : MonoBehaviour
{
    //static bool isLoaded = true; //updated by jani kauhanen 12may22 - fixed island scene and minigame pause.

    public static bool isPaused;

    public GameObject pauseMenuUI;
    /*
    void OnGUI()
    {
        if (isPaused)
            GUI.Label(new Rect(100, 100, 50, 30), "Game paused");
    }
    */

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            isPaused = !isPaused;
            GameTime();
        }


    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        
    }

    public void Running()
    {
        isPaused = !isPaused;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
       
    }

    public void GameTime()
    {
        if (isPaused)
        {
            Pause();
        }
        else
        {
            Running();
        }
    }

    public void LoadMenu()
    {
        isPaused = !isPaused;
        SceneManager.LoadScene("MAINMENU");
        Time.timeScale = 1f;
        
    }

    public void OptionsMenu()
    {
        
    }
}
