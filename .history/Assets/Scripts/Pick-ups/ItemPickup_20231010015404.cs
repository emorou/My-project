using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, ICollectible
{
    public Item item;

    public void Collect()
    {
        InventoryManager.instance.ListItems();
        Destroy(gameObject);
    }
}
