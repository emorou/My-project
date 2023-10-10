using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItemController : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private Image itemIcon;
    [SerializeField] private Button itemButton;
    public GameObject removeButton;
    
private void Update()
{
    if(InventoryManager.instance.isRemoveMode) removeButton.SetActive
}
    public void RemoveItem()
    {
        InventoryManager.instance.Remove(item);
        Destroy(gameObject);
    }
     
    public void SetItem(Item newItem)
    {
        item = newItem;
itemName.text = item.itemName;
itemIcon.sprite = item.itemIcon;
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
