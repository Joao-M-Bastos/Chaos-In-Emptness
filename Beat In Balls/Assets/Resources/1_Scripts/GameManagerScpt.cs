using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class GameManagerScpt : MonoBehaviour
{
    [SerializeField] CanvasScrpt canvasScrpt;

    bool isPlayerDead;

    static bool isPaused;
    public static bool IsPaused => isPaused;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (isPlayerDead)
            canvasScrpt.CantContinue();
        Time.timeScale = 0;
        isPaused = true;
        canvasScrpt.TurnOnPause();
    }
    
    public void UnpauseGame()
    {
        if (isPlayerDead)
            return;

        Time.timeScale = 1;
        isPaused = false;
        canvasScrpt.TurnOffPause();
    }

    internal void PlayerDied()
    {
        isPlayerDead = true;
    }

    public void Reiniciar()
    {
        Time.timeScale = 1;
        isPaused = false;
        canvasScrpt.TurnOffPause();

        SceneManager.LoadScene(0);
    }

    

}
