using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //static bool isLoaded = true;

    public static bool isPaused;
    /*
    void OnGUI()
    {
        if (isPaused)
            GUI.Label(new Rect(100, 100, 50, 30), "Game paused");
    }
    */
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            GameTime();
        }
    }
    
    static void Pause()
    {
        Time.timeScale = 0f;
        Debug.Log("ESC game is paused");
    }

    static void Running()
    {
        Time.timeScale = 1;
        Debug.Log("ESC Game is running again");
    }

    public static void GameTime()
    {
        if(isPaused)
        {
            Pause();
        }
        else
        {
            Running();
        }
    }
}
