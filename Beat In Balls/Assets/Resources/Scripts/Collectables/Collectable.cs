using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerScpt player;
        if(other.gameObject.TryGetComponent<PlayerScpt>(out player))
        {
            ItemCollected(player);
        }
    }

    public abstract void ItemCollected(PlayerScpt player);
}
