using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//https://www.youtube.com/watch?v=o0j7PdU88a4

public class FishingTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 30f;

    public static bool gamePaused;

    [SerializeField] Text CountdownText;

    void Start()
    {
        gamePaused = true;
        Pause();
        currentTime = startingTime;
    }

    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            gamePaused = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && gamePaused && currentTime > 0)
        {
            gamePaused = false;
            Pause();
            Debug.Log("Minigame has started");
        }

        currentTime -= 1 * Time.deltaTime;
        CountdownText.text = currentTime.ToString("0");

        if (currentTime < 0)
        {
            gamePaused = true;
            Pause();
            Debug.Log("Minigame ended, press space to continue");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("OVERWORLD");
            }
        }
    }

    void Pause()
    {
        if (gamePaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
