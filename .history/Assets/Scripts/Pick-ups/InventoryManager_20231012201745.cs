using System.Diagnostics.Contracts;
 using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public Transform itemContent;
    public GameObject inventoryItem;

    // public List<Item> InventoryItems = new List<Item>();
    public Dictionary<Item, int> InventoryItems = new Dictionary<Item, int>();
    public Toggle enableRemove;
    public bool isRemoveMode = false;

    private void Awake()
    {
        instance = this;
    }

void Update()
{
 if(enableRemove.isOn) isRemoveMode = true; else isRemoveMode = false;
}
    // public void Add(Item item)
    // {
    //     InventoryItems.Add(item);
    //     GameObject obj = Instantiate(inventoryItem, itemContent);
    //     obj.GetComponent<InventoryItemController>().SetItem(item);
    // }

    public void Add(Item item)
    {
        if (InventoryItems.ContainsKey(item))
        {
            // If the item already exists in the inventory, increase its quantity.
            InventoryItems[item]++;
        }
        else
        {
            // If the item is not in the inventory, add it with a quantity of 1.
            InventoryItems.Add(item, 1);
        }

        UpdateInventoryUI();
    }

    public void Remove(Item item)
    {
        InventoryItems.Remove(item);
    
    }

    public void UpdateInventoryUI()
    {
        // Clear the inventory UI.
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }

        // Populate the inventory UI based on the dictionary.
        foreach (var itemEntry in InventoryItems)
        {
            Item item = itemEntry.Key;
            int quantity = itemEntry.Value;

            GameObject obj = Instantiate(inventoryItem, itemContent);
            obj.GetComponent<InventoryItemController>().SetItem(item, quantity); // Pass item and quantity to the UI.
            if (enableRemove.isOn)
            {
                obj.transform.Find("Remove Button").gameObject.SetActive(true);
            }
        }
    }
    // public void ListItems()
    // {
    //     // foreach (Transform item in itemContent)
    //     // {
    //     //     Destroy(item.gameObject);
    //     // }
    //     foreach (var item in Items)
    //     {
    //         GameObject obj = Instantiate(inventoryItem, itemContent);
    //         var itemName = obj.transform.Find("Item Name").GetComponent<TMP_Text>();
    //         var itemIcon = obj.transform.Find("Item Icon").GetComponent<Image>();
    //         var removeButton = obj.transform.Find("Remove Button").gameObject;

    //         itemName.text = item.itemName;
    //         itemIcon.sprite = item.itemicon;

    //         if(enableRemove.isOn)
    //         {
    //             removeButton.gameObject.SetActive(true);
    //         }
    //     }

    //     SetInventoryItems();
    // }

    // public void SetInventoryItems()
    // {
    //     InventoryItems = itemContent.GetComponentsInChildren<InventoryItemController>();

    //     // for (int i = 0; i < Items.Count; i++)
    //     // {
    //     //     InventoryItems[i].AddItem(Items[i]);
            
    //     // }
    // }

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