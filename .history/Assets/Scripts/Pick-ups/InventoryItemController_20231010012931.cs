using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    Item item;
    
    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void UseItem()
    {
        switch (item.itemType)
        {
            case Item.ItemType.Potion:
            PlayerStats.Instance.RestoreHealth(item.value);
            break;

            case Item.ItemType.Ammo: 
            KnifeController.instance.RestoreAmmo(item.value);  
            break;

            default:
            break;
        }

        
    }
}
