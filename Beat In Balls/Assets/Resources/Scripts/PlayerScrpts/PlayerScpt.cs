using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScpt : MonoBehaviour
{
    PlayerCombat playerCombat;
    [SerializeField]GameManagerScpt gameManager;


    private void Awake()
    {
        playerCombat = GetComponent<PlayerCombat>();
    }

    public void TakeDamage(int value)
    {
        if (playerCombat.TakeDamage(value))
        {
            gameManager.PauseGame();
            Destroy(this.gameObject);
        }
    }
}
