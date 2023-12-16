using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] int life;
    [SerializeField] TextMeshProUGUI lifeIndicator;

    private void Start()
    {
        lifeIndicator.text = "Vida: " + life;
    }
    public bool TakeDamage(int value)
    {
        life -= value;
        lifeIndicator.text = "Vida: " + life;
        return life < 1;
    }
}
