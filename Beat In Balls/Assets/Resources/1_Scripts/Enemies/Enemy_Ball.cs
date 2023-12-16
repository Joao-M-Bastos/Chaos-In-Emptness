using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ball : Enemy
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

        if (IsUnderEffect())
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
        Vector3 ballVelocity = enemyRigidbody.velocity;

        ballVelocity += this.transform.forward * 4;

        enemyRigidbody.velocity = ballVelocity;

        stunCooldown = 1.5f;

        stuned = true;
    }

    public override bool CanAttack()
    {
        if (!stuned && IsCloseFromPlayer(5))
            return true;
        return false;
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

        
        enemyRigidbody.velocity = ballVelocity;
    }

    public override void OnCollisionEnter(Collision collision)
    {
        PlayerScpt player;
        if (collision.gameObject.TryGetComponent<PlayerScpt>(out player))
        {
            Destroy(this.gameObject);
            player.TakeDamage(dano);
        }
    }

    public override void SpecialAttack()
    {
        throw new System.NotImplementedException();
    }
}
