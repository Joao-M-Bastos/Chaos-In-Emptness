using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    float cooldown, cooldownBase;
    bool isAutoFire;
    int ammoCurrent, ammoCapacity;
    public int CurrentAmmo => ammoCurrent;
    float rechargeTime;
    bool isRecharding;
    bool isLocked;
    public bool IsRecharding => isRecharding;
    public bool IsLocked => isLocked;


    protected void SetValues(float cooldownBase, bool isAutoFire, int ammoCapacity, float rechargeTime)
    {
        this.cooldownBase = cooldownBase;
        this.cooldown = 0;
        this.isAutoFire = isAutoFire;
        this.ammoCapacity = ammoCapacity;
        this.ammoCurrent = 0;
        this.rechargeTime = rechargeTime;
    }

    public void MouseClicked(GameObject bullet)
    {
        if (!IsLocked || !IsRecharding)
        {
            if (HasAmmo())
                Shoot(bullet);
            else if(!IsRecharding)
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
        if (cooldown <= 0)
            return true;
        cooldown -= Time.deltaTime;
        return false;
    }

    public bool HasAmmo()
    {
        return ammoCurrent > 0;
    }

    public void StartRecharging()
    {
        if(ammoCurrent != ammoCapacity)
            StartCoroutine(Recharging());
    }

    public IEnumerator Recharging()
    {
        isRecharding = true;
        yield return new WaitForSeconds(rechargeTime);
        ammoCurrent = ammoCapacity;
        isRecharding = false;
    }

    protected void AmmoSpent(int value)
    {
        ammoCurrent-=value;
        cooldown = cooldownBase;
    }

    protected void AddChangesToBullet(Bullets bullet, float bulletSizeChange, int bulletDamageChange, int bulletSpeedChange, float bulletLifeSpamChange)
    {
        bullet.gameObject.transform.localScale *= (bulletSizeChange + 1);
        bullet.AddToDano(bulletDamageChange);
        bullet.AddToVelocidade(bulletSpeedChange);
        bullet.AddToLifeTime(bulletLifeSpamChange);
    }
}
