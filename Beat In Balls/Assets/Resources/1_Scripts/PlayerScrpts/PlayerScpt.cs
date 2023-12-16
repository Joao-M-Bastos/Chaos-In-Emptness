using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScpt : MonoBehaviour
{
    PlayerCombat playerCombat;
    HandManager playerHand;
    [SerializeField]GameManagerScpt gameManager;

    Efeitos sobreEfeitos;
    Efeitos efeitoNeutro = new Efeito_Neutro();

    private void Awake()
    {
        playerCombat = GetComponent<PlayerCombat>();
        playerHand = GetComponentInChildren<HandManager>();
    }

    //Combat

    public void TakeDamage(int value)
    {
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
    public void ApplyEffect(Efeitos effect)
    {
        sobreEfeitos = effect;
    }

    public bool IsUnderEffect()
    {
        return sobreEfeitos.GetName() != efeitoNeutro.GetName();
    }

    public void ClearEffect()
    {
        ApplyEffect(efeitoNeutro);
    }
}
