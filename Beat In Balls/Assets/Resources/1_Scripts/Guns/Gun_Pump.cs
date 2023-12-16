using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Pump : Gun
{
    [SerializeField] Transform[] startingPoint;

    [SerializeField] float cooldownBasePump;
    [SerializeField] bool isAutoFirePump;
    [SerializeField] int ammoCapacityPump;
    [SerializeField] float rechargeTimePump;

    [SerializeField] float bulletSizeChange;
    [SerializeField] int bulletSpeedChange;
    [SerializeField] int bulletDamageChange;
    [SerializeField] float bulletLifeSpamChange;

    private void Awake()
    {
        SetValues(cooldownBasePump, isAutoFirePump, ammoCapacityPump, rechargeTimePump);
    }

    public override void Shoot(GameObject bullet)
    {
        for (int i = 0; i < startingPoint.Length; i++)
        {
            GameObject bulletShoot = Instantiate(bullet, startingPoint[i].position, startingPoint[i].transform.rotation);

            Bullets bulletScript = bulletShoot.GetComponent<Bullets>();

            AddChangesToBullet(bulletScript, bulletSizeChange, bulletDamageChange, bulletSpeedChange, bulletLifeSpamChange);

        }
        AmmoSpent(1);
    }
}
