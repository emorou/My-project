using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour, ICollectible
{
    public Item item;

    public void Collect()
    {
        InventoryManager.instance.Add(item);
        InventoryManager.instance.ListItems();
        Destroy(gameObject);
    }
}
