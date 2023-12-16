using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScrpt : MonoBehaviour
{
    [SerializeField] GameObject pauseObj;
    [SerializeField] GameObject gameObj;
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
}
