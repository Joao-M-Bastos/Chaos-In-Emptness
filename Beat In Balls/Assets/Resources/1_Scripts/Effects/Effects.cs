using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effects
{
    protected float timeActive;

    public float GetTime()
    {
        return timeActive;
    }

    public abstract int EffectOnLife();

    public abstract float EffectOnSpeed();

    public abstract int EffectOnResistance();

    public abstract int EffectOnDamage();

    public abstract int EffectOnKnockback();

    public abstract float EffectOnAttackSpeed();
}
