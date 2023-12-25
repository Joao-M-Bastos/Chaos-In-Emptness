using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScpt : MonoBehaviour
{
    PlayerCombat playerCombat;
    HandManager playerHand;
    PlayerMovement playerMovement;
    [SerializeField]GameManagerScpt gameManager;

    int effectID;
    float effectTimer;
    bool isUndereffect;

    private void Awake()
    {
        playerCombat = GetComponent<PlayerCombat>();
        playerHand = GetComponentInChildren<HandManager>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            ApplyEffect(1);

        if (IsUnderEffect())
            TryCleatEffect();
    }

    //Combat

    public void TakeDamage(int value, Vector3 knockbackDirection, float _knockbackPower)
    {
        playerMovement.TakeKnockback(knockbackDirection, _knockbackPower);
        if (playerCombat.TakeDamage(value))
        {
            gameManager.PlayerDied();
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
    public void ApplyEffect(int _effectId)
    {
        if (isUndereffect)
            return;

        effectID = _effectId;

        Effects currentEffect = ListOfEffects.GetTargetEffect(effectID);

        isUndereffect = true;

        effectTimer = currentEffect.GetTime();

        playerCombat.ApplyEffect(currentEffect.EffectOnLife(), currentEffect.EffectOnResistance());

        playerHand.ApplyEffect(currentEffect.EffectOnDamage(), currentEffect.EffectOnKnockback(), currentEffect.EffectOnAttackSpeed());

        playerMovement.ApplyEffect(currentEffect.EffectOnSpeed());
    }

    public bool IsUnderEffect()
    {
        return isUndereffect;
    }

    public void TryCleatEffect()
    {
        effectTimer -= Time.deltaTime;
        if (effectTimer < 0)
            ClearEffect();
    }

    public void ClearEffect()
    {
        if (!isUndereffect)
            return;

        Effects currentEffect = ListOfEffects.GetTargetEffect(effectID);

        effectTimer = 0;
        isUndereffect = false;

        playerCombat.ClearEffect(currentEffect.EffectOnResistance());

        playerHand.ClearEffect(currentEffect.EffectOnDamage(), currentEffect.EffectOnKnockback(), currentEffect.EffectOnAttackSpeed());
        
        playerMovement.ClearEffect(currentEffect.EffectOnSpeed());
    }
}
