using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullets : MonoBehaviour
{
    [SerializeField] protected int effect, effectPotency;
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

    protected abstract void HitEnemy(GameObject enemy);

    protected abstract void HitPlayer(GameObject player);

    protected abstract void Move();

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
            HitEnemy(other.gameObject);
        else if (other.gameObject.TryGetComponent<PlayerCombat>(out PlayerCombat player))
            HitPlayer(other.gameObject);


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

    public void DealDamageToPlayer(GameObject player)
    {
        player.GetComponent<PlayerCombat>().TakeDamage(damage);
    }

    public void DealDamageToEnemy(GameObject enemy)
    {
        enemy.GetComponent<Enemy>().RecivedAttack(damage, this.transform.forward, knockbackValue);
    }

    public void TryApllyEffect()
    {

    }

    protected void CountLifeSpam()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
            DestroyBullet();
    }

}
