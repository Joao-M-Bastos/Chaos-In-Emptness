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

        ApplyEffectInTarget(0);
    }

    public void ApplyEffectInTarget(int effectID)
    {
        if (isPlayer)
            player.ApplyEffect(effectID);
        else
            enemy.ApplyEffect(effectID);
    }
}
