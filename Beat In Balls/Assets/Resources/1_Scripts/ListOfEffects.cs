using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfEffects : MonoBehaviour
{
    static Effects[] effects;
    // Start is called before the first frame update
    void Start()
    {
        effects = new Effects[]{
            new EffectSlow(10)
        };
    }

    public static Effects GetRandomEffect()
    {
        return effects[Random.Range(0,effects.Length)];
    }

    public static Effects GetTargetEffect(int value)
    {
        return effects[value];
    }
}
