using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] int life, resistance;
    [SerializeField] TextMeshProUGUI lifeIndicator;

    private void Start()
    {
        lifeIndicator.text = "Vida: " + life;
    }
    public bool TakeDamage(int damage)
    {
        int dmgNonResisted = damage - resistance;

        if (dmgNonResisted > 0)
            life -= dmgNonResisted;
        lifeIndicator.text = "Vida: " + life;
        return life < 1;
    }
}
