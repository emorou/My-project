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

    public List<Item> InventoryItems = new List<Item>();
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

    // public void Remove(Item item)
    // {
    //     InventoryItems.Remove(item);
    
    // }
     public void Add(Item item)
    {
        // Check if the item is already in the inventory
        Item existingItem = InventoryItems.Find(i => i.id == item.id);

        if (existingItem != null)
        {
            // If it exists, increase its quantity and update the UI
            existingItem.quantity++;
            UpdateQuantityText(existingItem);
        }
        else
        {
            // If it doesn't exist, add it to the inventory
            InventoryItems.Add(item);
            GameObject obj = Instantiate(inventoryItem, itemContent);
            obj.GetComponent<InventoryItemController>().SetItem(item);
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