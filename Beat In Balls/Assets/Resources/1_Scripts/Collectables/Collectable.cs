using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] int itemIndex;
    [SerializeField] CollectableTypes collectableTypes;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<PlayerScpt>(out PlayerScpt player))
        {
            ItemCollected(player);
            Destroy(this.gameObject);
        }
    }

    public void ItemCollected(PlayerScpt player)
    {
        switch (collectableTypes)
        {
            case CollectableTypes.GUN:
                player.ChangeGun(itemIndex);
                break;
            case CollectableTypes.AMMO:
                player.ChangeAmmo(itemIndex);
                break;
            case CollectableTypes.EQUIPS: //EQUIP

                break;
            case CollectableTypes.EFFECTS: //EFFECT

                break;

        }
        
    }
}
