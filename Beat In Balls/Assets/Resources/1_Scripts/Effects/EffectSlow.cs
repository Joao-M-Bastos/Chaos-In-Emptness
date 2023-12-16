using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSlow : Effects
{
    public EffectSlow(float value)
    {
        timeActive = value;
    }

    public override float EffectOnAttackSpeed()
    {
        return -10;
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
        return 0;
    }

    public override float EffectOnSpeed()
    {
        return -50;
    }
}
