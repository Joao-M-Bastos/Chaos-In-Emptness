using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullets : MonoBehaviour
{
    protected int damage, knockbackValue;
    protected float lifeTime, speed;

    protected void SetBulletValues(
        float velocidade, int dano, int valorEmpurrao,
        float tempoVida)
    {
        this.speed = velocidade;
        this.damage = dano;
        this.knockbackValue = valorEmpurrao;
        this.lifeTime = tempoVida;
    }

    public void AddToDano(int value)
    {
        damage += value;
    }
    public void AddToVelocidade(int value)
    {
        speed += value;
    }

    public void AddToLifeTime(float value)
    {
        lifeTime += value;
    }

    protected abstract void OnDestroy();

    protected abstract void HitEnemy(GameObject alvo);

    protected abstract void Move();

    private void OnTriggerEnter(Collider other)
    {
        HitEnemy(other.gameObject);
        DestroyBullet();
        
    }

    protected void DestroyBullet()
    {
        Destroy(this.gameObject);
    }

    private void FixedUpdate()
    {
        Move();
        CountLifeSpam();
    }

    protected abstract void CountLifeSpam();

}
