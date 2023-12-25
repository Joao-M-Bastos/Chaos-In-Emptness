using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Pistol : Gun
{
    [SerializeField] Transform startingPoint;

    public override void Shoot(GameObject bullet)
    {
        GameObject bulletShoot = Instantiate(bullet, startingPoint.position, startingPoint.transform.rotation);

        Bullets bulletScript = bulletShoot.GetComponent<Bullets>();

        AddChangesToBullet(bulletScript, bulletSizeChange, bulletDamageChange, bulletSpeedChange, bulletLifeSpamChange);

        AmmoSpent(1);
    }
}
