using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBullet : Bullets
{
    [SerializeField] GameObject explosiveArea;

    protected override void HitPlayer(PlayerScpt player)
    {
        DealDamageToPlayer(player);
    }

    protected override void HitEnemy(Enemy enemy)
    {
        DealDamageToEnemy(enemy);
    }

    protected override void Move()
    {
        this.transform.position += this.transform.forward * (speed / 10);
    }

    protected override void OnDestroy()
    {
        Instantiate(explosiveArea, this.transform.position, Quaternion.identity);
    }
}
