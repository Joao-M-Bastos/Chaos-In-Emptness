using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Efeitos
{
    protected string nome;

    public string GetName()
    {
        return nome;
    }

    public abstract int EfeitoNaVida();

    public abstract float EfeitoNaVelocidade();

    public abstract float EfeitoNoDano();
}
