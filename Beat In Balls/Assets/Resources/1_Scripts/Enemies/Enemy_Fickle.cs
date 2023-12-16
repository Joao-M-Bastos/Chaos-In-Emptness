using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Fickle : Enemy
{

    [SerializeField] private float randomDashCooldownBase;
    private float randomDashCurrentCooldown;

    private void Start()
    {
        SetUnivesalValues();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManagerScpt.IsPaused || player == null || velocidade == 0)
            return;

        if (CanAttack())
            Attack();

        if (CanUseSpecial())
            SpecialAttack();

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
        Vector3 fickleVelocity = enemyRigidbody.velocity;

        fickleVelocity += this.transform.forward * 6;

        enemyRigidbody.velocity = fickleVelocity;

        stunCooldown = 1.5f;

        stuned = true;
    }

    public override void FollowPlayer()
    {
        transform.LookAt(player.transform.position);

        Vector3 fickleVelocity = enemyRigidbody.velocity;

        if (getSpeedFromVelocity(fickleVelocity) < velocidade)
        { 
            fickleVelocity += this.transform.forward;
        }

        fickleVelocity *= 0.9f;

        enemyRigidbody.velocity = fickleVelocity;
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

    public override bool CanAttack()
    {
        if (!stuned && IsCloseFromPlayer(5))
            return true;
        return false;
    }

    public override bool CanUseSpecial()
    {
        if (stunCooldown < 0)
            stuned = false;

        if (randomDashCurrentCooldown < 0)
        {
            randomDashCurrentCooldown = randomDashCooldownBase;
            return true;
        }
        randomDashCurrentCooldown -= Time.deltaTime;

        return false;
    }

    public override void SpecialAttack()
    {
        Vector3 fickleVelocity = enemyRigidbody.velocity;

        fickleVelocity = new Vector3(Random.Range(-1,1f), Random.Range(-1, 1f), 0).normalized * 10;

        enemyRigidbody.velocity = fickleVelocity;

        stunCooldown = 2f;

        stuned = true;
    }
}
