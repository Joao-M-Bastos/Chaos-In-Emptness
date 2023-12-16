using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet_Basic : Bullets
{
    protected override void HitEnemy(GameObject enemy)
    {
        enemy.GetComponent<Enemy>().RecivedAttack(0, this.transform.forward, knockbackValue);
    }

    protected override void HitPlayer(GameObject player)
    {
        player.GetComponent<PlayerCombat>().TakeDamage(damage);
        
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
