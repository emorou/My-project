using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour, ICollectible
{
    public int healthToRestore;
    public Item item;

    public void Collect()
    {
        InventoryManager.instance.Add(item);
        // PlayerStats player = FindObjectOfType<PlayerStats>();
        // player.RestoreHealth(healthToRestore);
        Destroy(gameObject);
        InventoryManager.instance.Add(Item);
        InventoryManager.instance.ListItems();
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Collect();
    }
}
