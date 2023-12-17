using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ranged : Enemy
{
    [SerializeField] protected int viewDistance;

    [SerializeField] protected float rechargeCooldownBase;
    private float rechargeCooldown;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform[] bulletSpawnPoints;
    

    protected bool IsRecharged()
    {
        if (rechargeCooldown < 0)
        {
            rechargeCooldown = rechargeCooldownBase;
            return true;
        }

        rechargeCooldown -= Time.deltaTime * attackspeed;

        return false;
    }

    protected void Shoot()
    {
        foreach(Transform t in bulletSpawnPoints)
        {
            Instantiate(bullet, t.position, t.rotation);
        }
    }
}
