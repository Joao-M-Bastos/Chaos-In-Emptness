using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    [SerializeField] public float baseShootCooldown;
    [SerializeField] bool isAutoFire;
    [SerializeField] int ammoCapacity;
    [SerializeField] public float baseRechargeTime;

    [SerializeField] protected float bulletSizeChange;
    [SerializeField] protected int bulletSpeedChange;
    [SerializeField] protected int bulletDamageChange;
    [SerializeField] protected int bulletKnockbackChange;
    [SerializeField] protected float bulletLifeSpamChange;

    int ammoCurrent;
    float shootCooldown;
    float rechargeTime;
    public float baseRecoverTime = 1;
    public float recoverTime;

    bool recharge;
    bool isLocked;
    public bool IsLocked => isLocked;
    public int CurrentAmmo => ammoCurrent;


    private void Start()
    {
        ammoCurrent = ammoCapacity;
        shootCooldown = baseShootCooldown;
        rechargeTime = baseRechargeTime;
        recoverTime = baseRecoverTime;
    }

    public void MouseClicked(GameObject bullet)
    {
        if (!IsLocked || !isRecharging())
        {
            if (HasAmmo())
                Shoot(bullet);
            else if(!isRecharging())
                StartRecharging();
        }
    }

    public void MousePressed(GameObject bullet)
    {
        if (isAutoFire)
            MouseClicked(bullet);
    }

    public abstract void Shoot(GameObject bullet);

    public bool CheckCoolDown()
    {
        if (shootCooldown <= 0)
            return true;
        shootCooldown -= Time.deltaTime * recoverTime;
        return false;
    }

    public bool HasAmmo()
    {
        return ammoCurrent > 0;
    }

    public void StartRecharging()
    {
        if (ammoCurrent != ammoCapacity)
            rechargeTime = baseRechargeTime;
        recharge = true;
    }

    public void ManageRecharge()
    {
        if (isRecharging())
        {
            rechargeTime -= Time.deltaTime * recoverTime;
        }
        else if (recharge)
        {
            ammoCurrent = ammoCapacity;
            recharge = false;
        }
    }

    public bool isRecharging()
    {
        return rechargeTime >= 0;
    }

    protected void AmmoSpent(int value)
    {
        ammoCurrent-=value;
        shootCooldown = baseShootCooldown;
    }

    protected void AddChangesToBullet(Bullets bullet, float bulletSizeChange, int bulletDamageChange, int bulletSpeedChange, float bulletLifeSpamChange)
    {
        bullet.gameObject.transform.localScale *= (bulletSizeChange + 1);
        bullet.AddToDano(bulletDamageChange);
        bullet.AddToVelocidade(bulletSpeedChange);
        bullet.AddToLifeTime(bulletLifeSpamChange);
    }
}
