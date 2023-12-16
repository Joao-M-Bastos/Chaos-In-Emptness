using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectApplyer : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] PlayerScpt player;
    bool isPlayer = true;

    private void Start()
    {
        if (player == null)
        {
            isPlayer = false;
            enemy = this.gameObject.GetComponent<Enemy>();
        }
    }

    public void ApplyEffectInTarget(int effectID)
    {
        if (isPlayer)
            player.ApplyEffect(effectID);
        else
            enemy.ApplyEffect(effectID);
    }
}
