using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, ICollectible
{
    public Item item;

    void Update()
    {
        if(item.quantity == 0)
        {
            Destory(gameObject);
        }
    }
    public void Collect()
    {
        InventoryManager.instance.Add(item);
        Destroy(gameObject);
    }
}
