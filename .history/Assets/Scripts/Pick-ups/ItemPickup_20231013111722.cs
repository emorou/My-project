using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, ICollectible
{
    public Item item;

    public Update()
    public void Collect()
    {
        InventoryManager.instance.Add(item);
        Destroy(gameObject);
    }
}
