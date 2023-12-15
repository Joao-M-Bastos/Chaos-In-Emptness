using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Basic : Bullets
{
    [SerializeField] int basicDamage, basicKnockback;
    [SerializeField] float basicLifeTime, basicSpeed;

    private void Awake()
    {
        SetBulletValues(basicSpeed, basicDamage, basicKnockback * 10, basicLifeTime);
    }

    protected override void CountLifeSpam()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
            DestroyBullet();
    }

    protected override void HitEnemy(GameObject gameObject)
    {
        gameObject.GetComponent<Enemy>().RecivedAttack(damage, this.transform.forward, knockbackValue);
    }
    
    protected override void Move()
    {
        this.transform.position += this.transform.forward * (speed / 10);
    }

    protected override void OnDestroy()
    {
        //throw new System.NotImplementedException();
    }
}
