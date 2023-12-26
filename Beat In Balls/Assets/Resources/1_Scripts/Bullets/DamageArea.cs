using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    [SerializeField] protected int effectID;
    [SerializeField] protected int effectPotency;
    [SerializeField] protected bool hasEffect;


    [SerializeField] protected int damage, knockbackValue;
    [SerializeField] protected float lifeTime;

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;

        if(lifeTime < 0)
            Destroy(this.gameObject);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            DealDamageToEnemy(enemy);
            TryApllyEffect(other.gameObject.GetComponent<EffectApplyer>());
            Debug.Log("a");
        }
        else if (other.gameObject.TryGetComponent<PlayerScpt>(out PlayerScpt player))
        {
            DealDamageToPlayer(player);
            TryApllyEffect(other.gameObject.GetComponent<EffectApplyer>());
        }
    }

    public void DealDamageToPlayer(PlayerScpt player)
    {
        player.TakeDamage(damage, this.transform.forward, knockbackValue);
    }

    public void DealDamageToEnemy(Enemy enemy)
    {
        enemy.RecivedAttack(damage, this.transform.forward, knockbackValue);
    }

    public void TryApllyEffect(EffectApplyer effectApplyer)
    {
        if (!hasEffect)
            return;

        float temp = Random.Range(0, 1f);

        if (temp < effectPotency)
        {
            effectApplyer.ApplyEffectInTarget(effectID);
        }
    }
}
