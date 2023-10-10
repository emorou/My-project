using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    Item item;
    
    public Button removeButton;

    public void RemoveItem()
    {
        InventoryManager.instance.Remove(item);
        Destroy(gameObject);
    }
     
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
        
        RemoveItem();
    }
}
