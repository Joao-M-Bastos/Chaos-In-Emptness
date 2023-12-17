using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScpt : MonoBehaviour
{
    PlayerCombat playerCombat;
    HandManager playerHand;
    PlayerMovement playerMovement;
    [SerializeField]GameManagerScpt gameManager;

    float sobreEfeitos;

    private void Awake()
    {
        playerCombat = GetComponent<PlayerCombat>();
        playerHand = GetComponentInChildren<HandManager>();
    }

    //Combat

    public void TakeDamage(int value, Vector3 knockbackDirection, float knockbackPower)
    {
        playerMovement.TakeKnockback(knockbackDirection, knockbackPower);
        if (playerCombat.TakeDamage(value))
        {
            gameManager.PauseGame();
            Destroy(this.gameObject);
        }
    }

    //HandManager

    public void ChangeGun(int gunID)
    {
        playerHand.EquipGun(gunID);
    }

    public void ChangeAmmo(int ammoID)
    {
        playerHand.EquipAmmo(ammoID);
    }

    //Efeitos
    public void ApplyEffect(float time)
    {
        sobreEfeitos = time;


    }

    public bool IsUnderEffect()
    {
        return sobreEfeitos > 0;
    }

    public void ClearEffect()
    {
        
    }
}
