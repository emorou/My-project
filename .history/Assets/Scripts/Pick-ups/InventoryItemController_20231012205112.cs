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
            quantity--;
            quantityText.text = quantity.ToString();
            break;

            case Item.ItemType.Ammo: 
            KnifeController.instance.RestoreAmmo(item.value);  
            quantity--;
            break;

            default:
            break;
        }
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
