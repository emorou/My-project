using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, ICollectible
{
    public Item item;

    public void Collect()
    {
        AudioManager.instance. PlaySFX("Pickup Item");
        InventoryManager.instance.Add(item);
        Destroy(gameObject);
    }
}
