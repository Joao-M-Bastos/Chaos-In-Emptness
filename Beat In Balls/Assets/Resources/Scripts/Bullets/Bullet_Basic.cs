using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Basic : Bullets
{
    protected override void HitPlayer(GameObject enemy)
    {
        
    }

    protected override void HitEnemy(GameObject enemy)
    {
        DealDamageToEnemy(enemy);
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
