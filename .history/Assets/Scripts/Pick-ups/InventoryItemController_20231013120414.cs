using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItemController : MonoBehaviour
{
    private Item item;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private Image itemIcon;
    public GameObject removeButton;
    public int quantity;
    public TMP_Text quantityText;

private void Update()
{
    if(InventoryManager.instance.isRemoveMode) removeButton.SetActive(true);
    else removeButton.SetActive(false);
    quantity = 
}
    public void RemoveItem()
    {
        InventoryManager.instance.Remove(item);
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
            quantityText.text = quantity.ToString();
            quantity--;
            if(InventoryManager.instance.existingItem.quantity <= 0)
            {
                Destroy(gameObject);
            }
            break;

            case Item.ItemType.Ammo: 
            KnifeController.instance.RestoreAmmo(item.value);  
            quantity--;
            break;

            default:
            break;
        }
        RemoveItem();
    }

     public void UpdateQuantityText()
    {
        quantityText.text = item.quantity.ToString();
    }
    public Item GetItem()
    {
        return item;
    }
}
