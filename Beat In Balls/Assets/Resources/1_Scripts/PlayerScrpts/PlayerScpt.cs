using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScpt : MonoBehaviour
{
    PlayerCombat playerCombat;
    HandManager playerHand;
    [SerializeField]GameManagerScpt gameManager;


    private void Awake()
    {
        playerCombat = GetComponent<PlayerCombat>();
        playerHand = GetComponentInChildren<HandManager>();
    }

    public void TakeDamage(int value)
    {
        if (playerCombat.TakeDamage(value))
        {
            gameManager.PauseGame();
            Destroy(this.gameObject);
        }
    }

    public void ChangeGun(int gunID)
    {
        playerHand.EquipGun(gunID);
    }

    public void ChangeAmmo(int ammoID)
    {
        playerHand.EquipAmmo(ammoID);
    }
}
