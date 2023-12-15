using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Pistol : Gun
{
    [SerializeField] Transform startingPoint;

    [SerializeField] float cooldownBasePistol;
    [SerializeField] bool isAutoFirePistol;
    [SerializeField] int ammoCapacityPistol;
    [SerializeField] float rechargeTimePistol;

    [SerializeField] float bulletSizeChange;
    [SerializeField] int bulletSpeedChange;
    [SerializeField] int bulletDamageChange;
    [SerializeField] float bulletLifeSpamChange;

    private void Awake()
    {
        SetValues(cooldownBasePistol, isAutoFirePistol, ammoCapacityPistol, rechargeTimePistol);
    }

    public override void Shoot(GameObject bullet)
    {
        GameObject bulletShoot = Instantiate(bullet, startingPoint.position, startingPoint.transform.rotation);

        Bullets bulletScript = bulletShoot.GetComponent<Bullets>();

        AddChangesToBullet(bulletScript, bulletSizeChange, bulletDamageChange, bulletSpeedChange, bulletLifeSpamChange);

        AmmoSpent(1);
    }
}
