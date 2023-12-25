using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectFrenezy : Effects
{
    public EffectFrenezy(float value)
    {
        timeActive = value;
    }

    public override float EffectOnAttackSpeed()
    {
        return +50;
    }

    public override int EffectOnDamage()
    {
        return 0;
    }

    public override int EffectOnKnockback()
    {
        return 0;
    }

    public override int EffectOnLife()
    {
        return 0;
    }

    public override int EffectOnResistance()
    {
        return -2;
    }

    public override float EffectOnSpeed()
    {
        return 0;
    }
}
