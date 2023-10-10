 using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public List<Item> Items = new List<Item>();

    public Transform itemContent;
    public GameObject inventoryItem;

    public InventoryItemController[] InventoryItems;
    public Toggle enableRemove;

    private void Awake()
    {
        instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
        // Find the index of the item in the InventoryItems array
         int itemIndex = -1;
        for (int i = 0; i < InventoryItems.Length; i++)
        {
        if (InventoryItems[i].tem == item)
        {
            itemIndex = i;
            break;
        }
    }

    // If the item was found in InventoryItems, remove it
    if (itemIndex != -1)
    {
        Destroy(InventoryItems[itemIndex].gameObject);
        // Shift the remaining items in the array to fill the gap
        for (int i = itemIndex + 1; i < InventoryItems.Length; i++)
        {
            InventoryItems[i - 1] = InventoryItems[i];
        }
        // Resize the array
        Array.Resize(ref InventoryItems, InventoryItems.Length - 1);
    }

    public void ListItems()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in Items)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
            var itemName = obj.transform.Find("Item Name").GetComponent<TMP_Text>();
            var itemIcon = obj.transform.Find("Item Icon").GetComponent<Image>();
            var removeButton = obj.transform.Find("Remove Button").gameObject;

            itemName.text = item.itemName;
            itemIcon.sprite = item.itemicon;

            if(enableRemove.isOn)
            {
                removeButton.gameObject.SetActive(true);
            }
        }

        SetInventoryItems();
    }

    public void SetInventoryItems()
    {
        InventoryItems = itemContent.GetComponentsInChildren<InventoryItemController>();

        for (int i = 0; i < Items.Count; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
            
        }
    }

    public void EnableItemsRemove()
    {
        if(enableRemove.isOn)
        {
            foreach (Transform item in itemContent)
            {
                item.Find("Remove Button").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in itemContent)
            {
                item.Find("Remove x`Button").gameObject.SetActive(false);
            }   
        }
    }
}
