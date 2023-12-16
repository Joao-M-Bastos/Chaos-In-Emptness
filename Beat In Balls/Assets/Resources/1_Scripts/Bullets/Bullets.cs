using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Bullets : MonoBehaviour
{
    [SerializeField] protected Efeitos effect;
    [SerializeField] protected int effectPotency;
    [SerializeField] protected bool hasEffect;
    

    [SerializeField] protected int damage, knockbackValue;
    [SerializeField] protected float lifeTime, speed;

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

    protected abstract void HitEnemy(Enemy enemy);

    protected abstract void HitPlayer(PlayerScpt player);

    protected abstract void Move();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            HitEnemy(enemy);
            TryApllyEffect(other.gameObject.GetComponent<EffectApplyer>());
        }
        else if (other.gameObject.TryGetComponent<PlayerScpt>(out PlayerScpt player))
        {
            HitPlayer(player);
            TryApllyEffect(other.gameObject.GetComponent<EffectApplyer>());
        }

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

    public void DealDamageToPlayer(PlayerScpt player)
    {
        player.TakeDamage(damage);
    }

    public void DealDamageToEnemy(Enemy enemy)
    {
        enemy.RecivedAttack(damage, this.transform.forward, knockbackValue);
    }

    public void TryApllyEffect(EffectApplyer effectApplyer)
    {
        if (!hasEffect)
            return;

        float temp = Random.Range(0, 1f);
        if(temp < effectPotency)
        {
            effectApplyer.ApplyEffectInTarget(effect);
        }
    }

    protected void CountLifeSpam()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
            DestroyBullet();
    }

}
