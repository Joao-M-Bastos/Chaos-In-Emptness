using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Efeitos
{
    protected string nome;
    protected float timeActive;
      
    public string GetName()
    {
        return nome;
    }

    public abstract int EffectOnLife();

    public abstract float EffectOnSpeed();

    public abstract float EffectOnResistance();
}
