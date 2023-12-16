using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    //Valores
    protected GameObject player;
    [SerializeField]protected Rigidbody enemyRigidbody;

    [SerializeField] protected int vida, dano, resistenciaEmpurrao, empurrao;
    [SerializeField] protected float velocidadeBase;

    protected float velocidade, stunCooldown;

    protected bool stuned;

    Efeitos sobreEfeitos;
    Efeitos efeitoNeutro = new Efeito_Neutro();
    

    //BaseValues
    protected void SetUnivesalValues()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyRigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    //Condições
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

    //Ações
    public abstract void FollowPlayer();

    public abstract void Attack();

    public abstract void SpecialAttack();

    public void RecivedAttack(int damage, Vector3 projectForward, int bulletKnockbackValue)
    {
        this.vida -= damage;
        Vector3 direction = projectForward;
        float knockBackValue = bulletKnockbackValue - resistenciaEmpurrao;

        if (empurrao < 0)
            empurrao = 0;

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
    public void ReciveEffect(Efeitos effect) {
        sobreEfeitos = effect;
    }

    public bool IsUnderEffect()
    {
        if(sobreEfeitos.GetName() != efeitoNeutro.GetName())
        {
            return true;
        }
        return false;
    }

    public void ClearEffect()
    {
        ReciveEffect(efeitoNeutro);

    }

    protected float getSpeedFromVelocity(Vector3 playerVelocity)
    {
        return Mathf.Abs(playerVelocity.x) + Mathf.Abs(playerVelocity.y) + Mathf.Abs(playerVelocity.z);
    }

    public abstract void EfectEfect();
}
