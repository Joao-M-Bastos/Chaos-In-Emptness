using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfEffects : MonoBehaviour
{
    Efeitos[] effects;
    // Start is called before the first frame update
    void Start()
    {
        effects = new Efeitos[]{
            new Efeito_Neutro(),
            new StunEffect()
        };
    }

    public Efeitos GetRandomEffect()
    {
        return effects[Random.Range(0,effects.Length)];
    }

    public Efeitos GetTargetEffect(int value)
    {
        return effects[value];
    }
}
