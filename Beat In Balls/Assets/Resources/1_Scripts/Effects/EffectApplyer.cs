using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectApplyer : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] PlayerScpt player;
    bool isPlayer;

    private void Start()
    {
        if (enemy == null)
            isPlayer = true;

        ApplyEffectInTarget(new Efeito_Neutro());
    }

    public void ApplyEffectInTarget(Efeitos efeito)
    {
        if (isPlayer)
            player.ApplyEffect(efeito);
        else
            enemy.ApplyEffect(efeito);
    }
}
