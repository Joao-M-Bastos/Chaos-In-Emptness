using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet_Basic : Bullets
{
    protected override void HitEnemy(Enemy enemy)
    {
        enemy.RecivedAttack(0, this.transform.forward, knockbackValue);
    }

    protected override void HitPlayer(PlayerScpt player)
    {
        player.TakeDamage(damage,this.transform.forward, knockbackValue);
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
