using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, ICollectible
{
    public Item item;
    public GameObject 
    void Update()
    {
        if(item.quantity == 0)
        {
            Destroy(gameObject);
        }
    }
    public void Collect()
    {
        InventoryManager.instance.Add(item);
        Destroy(gameObject);
    }
}