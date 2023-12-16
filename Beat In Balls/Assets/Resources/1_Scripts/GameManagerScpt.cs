using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManagerScpt : MonoBehaviour
{
    [SerializeField]CanvasScrpt canvasScrpt;

    static bool isPaused;
    public static bool IsPaused => isPaused;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        Time.timeScale = 0;
        isPaused = true;
        canvasScrpt.TurnOnPause();
    }
    
    public void UnpauseGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        canvasScrpt.TurnOffPause();
    }

    public void Reiniciar()
    {
        UnpauseGame();

        SceneManager.LoadScene(0);
    }

}
