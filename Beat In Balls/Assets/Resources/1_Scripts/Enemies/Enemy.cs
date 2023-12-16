using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    //Valores
    protected GameObject player;
    protected Rigidbody enemyRigidbody;

    [SerializeField] protected int vidaBase, danoBase, resistanceBase, resistenciaEmpurraoBase, empurraoBase;
    [SerializeField] protected float velocidadeBase, attackspeedBase;

    protected int vida, dano, resistance, resistenciaEmpurrao, empurrao;
    protected float velocidade, attackspeed;

    protected float stunCooldown;

    protected bool stuned;

    int effectID;
    float effectTimer;
    

    //BaseValues
    protected void SetUnivesalValues()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyRigidbody = this.gameObject.GetComponent<Rigidbody>();

        vida = vidaBase;
        dano = danoBase;
        resistance = resistanceBase;
        empurrao = empurraoBase;
        velocidade = velocidadeBase;
        attackspeed = attackspeedBase;
    }

    //Condições ou Calculos
    public abstract bool CanAttack();

    public bool IsCloseFromPlayer(int distance)
    {
        if (player == null)
            return false;
        return Vector3.Distance(this.transform.position, player.transform.position) < distance;
    }
    
    public bool RecoveredFromAttack()
    {
        if (stunCooldown < 0)
            stuned = false;
        else
            stunCooldown -= Time.deltaTime;

        return !stuned;
    }

    public abstract bool CanUseSpecial();

    public virtual void OnCollisionEnter(Collision collision)
    {
        PlayerScpt player;
        if (collision.gameObject.TryGetComponent<PlayerScpt>(out player))
        {
            player.TakeDamage(dano);
        }
    }
    protected float getSpeedFromVelocity(Vector3 playerVelocity)
    {
        return Mathf.Abs(playerVelocity.x) + Mathf.Abs(playerVelocity.y) + Mathf.Abs(playerVelocity.z);
    }

    //Ações
    public abstract void FollowPlayer();

    public abstract void Attack();

    public abstract void SpecialAttack();

    public void RecivedAttack(int damage, Vector3 projectForward, int bulletKnockbackValue)
    {
        int dmgNonResisted = damage - resistance;

        if(dmgNonResisted > 0)
            vida -= dmgNonResisted;

        Vector3 direction = projectForward;
        float knockBackValue = bulletKnockbackValue - resistenciaEmpurrao;

        if (knockBackValue < 0)
            knockBackValue = 0;

        Debug.Log(knockBackValue);

        this.enemyRigidbody.AddForce(direction * (knockBackValue), ForceMode.Impulse);

        if (vida <= 0)
            this.Die();

        stuned = true;
        stunCooldown = 0.5f;
    }

    protected void Die()
    {
        Destroy(this.gameObject);
    }

    //Efeitos
    public void ApplyEffect(int _effectId)
    {
        effectID = _effectId;

        Effects currentEffect = ListOfEffects.GetTargetEffect(effectID);

        effectTimer = currentEffect.GetTime();

        vida += currentEffect.EffectOnLife();
        dano += danoBase * (currentEffect.EffectOnDamage()/100);
        resistance += resistanceBase * (currentEffect.EffectOnResistance()/100);
        empurrao += empurraoBase * (currentEffect.EffectOnLife()/100);
        velocidade += velocidadeBase * (currentEffect.EffectOnLife()/100);
        attackspeed += attackspeedBase * (currentEffect.EffectOnAttackSpeed()/100);
    }

    public bool IsUnderEffect()
    {
        return effectTimer > 0;
    }

    public void ClearEffect()
    {
        Effects currentEffect = ListOfEffects.GetTargetEffect(effectID);

        effectTimer = 0;

        dano -= danoBase * (currentEffect.EffectOnDamage() / 100);
        resistance -= resistanceBase * (currentEffect.EffectOnResistance() / 100);
        empurrao -= empurraoBase * (currentEffect.EffectOnLife() / 100);
        velocidade -= velocidadeBase * (currentEffect.EffectOnLife() / 100);
        attackspeed -= attackspeedBase * (currentEffect.EffectOnAttackSpeed() / 100);
    }
}
