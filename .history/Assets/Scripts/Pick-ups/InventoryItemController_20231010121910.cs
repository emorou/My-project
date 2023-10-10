using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItemController : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private Tex item;
    public Button removeButton;
    

    public void RemoveItem()
    {
        InventoryManager.instance.Remove(item);
        Destroy(gameObject);
    }
     
    public void SetItem(Item newItem)
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
