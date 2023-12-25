using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] int life, baseResistance;
    [SerializeField] TextMeshProUGUI lifeIndicator;

    int resistance;

    private void Start()
    {
        lifeIndicator.text = "Vida: " + life;
        resistance = baseResistance;
    }
    public bool TakeDamage(int damage)
    {
        int dmgNonResisted = damage - resistance;

        if (dmgNonResisted > 0)
            life -= dmgNonResisted;
        lifeIndicator.text = "Vida: " + life;
        return life < 1;
    }

    public void ApplyEffect(int _life, int _resistance)
    {
        life += _life;

        resistance += baseResistance * _resistance;
    }

    public void ClearEffect(int _resistance)
    {
        resistance -= baseResistance * _resistance;
    }
}
