using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sniper : Ranged
{
    private void Start()
    {
        SetUnivesalValues();
    }

    private void Update()
    {
        if (GameManagerScpt.IsPaused || player == null || velocidade == 0)
            return;

        if (CanAttack())
            Attack();

        if(IsUnderEffect())
            TryCleatEffect();
    }

    private void FixedUpdate()
    {
        if (GameManagerScpt.IsPaused && player == null)
            return;
        if (RecoveredFromAttack())
        {
            FollowPlayer();
        }
    }

    public override void Attack()
    {
        Shoot(shootCooldown);
    }

    public override bool CanAttack()
    {
        return IsCloseFromPlayer(viewDistance + 2) && IsRecharged();
    }

    public override bool CanUseSpecial()
    {
        throw new System.NotImplementedException();
    }

    public override void FollowPlayer()
    {
        

        transform.LookAt(player.transform.position);

        Vector3 ballVelocity = enemyRigidbody.velocity;

        if (getSpeedFromVelocity(ballVelocity) < velocidade)
        {
            ballVelocity += this.transform.forward;
        }

        ballVelocity *= 0.9f;

        if (IsCloseFromPlayer(viewDistance))
        {
            ballVelocity -= this.transform.forward;
            ballVelocity += this.transform.right * 10;
        }

        enemyRigidbody.velocity = ballVelocity;
    }

    public override void SpecialAttack()
    {
        throw new System.NotImplementedException();
    }
}
