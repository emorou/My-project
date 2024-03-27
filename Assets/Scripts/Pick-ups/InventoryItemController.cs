using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItemController : MonoBehaviour
{
    public Item item;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private Image itemIcon;
    public GameObject removeButton;
    public TMP_Text quantityText;

    private void Update()
    {
        if (InventoryManager.instance.isRemoveMode) removeButton.SetActive(true);
        else removeButton.SetActive(false);
    }
    public Item Item
    {
        get { return item; }
    }

    public void RemoveItem()
    {
        item.quantity = 0;
        gameObject.SetActive(false);
        // InventoryManager.instance.Remove(item);
        // Destroy(gameObject);
    }

    public void SetItem(Item newItem)
    {
        item = newItem;
        itemName.text = item.itemName;
        itemIcon.sprite = item.itemIcon;
        quantityText.text = item.quantity.ToString();

        if (item.quantity <= 0)
                {
                    gameObject.SetActive(false);
                }
                else
        gameObject.SetActive(true);
    }

    public void UseItem()
    {
        switch (item.itemType)
        {
            case Item.ItemType.Potion:
                PlayerStats.Instance.RestoreHealth(item.value);
                quantityText.text = item.quantity.ToString();
                item.quantity--;
                
                break;

            case Item.ItemType.Ammo:
                KnifeController.instance.RestoreAmmo(item.value);
                item.quantity--;
                break;

            default:
                break;
        }
        SetItem(item);
        // RemoveItem();
    }

    // public void UpdateQuantityText()
    // {
    //     quantityText.text = item.quantity.ToString();
    // }
    public Item GetItem()
    {
        return item;
    }
}
