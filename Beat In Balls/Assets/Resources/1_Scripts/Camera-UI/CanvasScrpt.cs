using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScrpt : MonoBehaviour
{
    [SerializeField] GameObject pauseObj;
    [SerializeField] GameObject gameObj;
    [SerializeField] GameObject continueButton;
    public void TurnOffPause()
    {
        pauseObj.SetActive(false);
        gameObj.SetActive(true);
    }

    public void TurnOnPause()
    {
        pauseObj.SetActive(true);
        gameObj.SetActive(false);
    }

    public void CantContinue()
    {
        continueButton.SetActive(false);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
