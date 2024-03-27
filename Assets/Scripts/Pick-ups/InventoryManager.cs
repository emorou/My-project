    using System.Diagnostics.Contracts;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour, IDataPersistence
{
    public static InventoryManager instance;

    public Transform itemContent;
    public GameObject inventoryItem;

    public List<Item> InventoryItems = new List<Item>();
    public List<InventoryItemController> itemInInventory;
    public Toggle enableRemove;
    public bool isRemoveMode = false;

    public GameObject inventoryUI;

    private void Awake()
    {
        instance = this;
        setupItem();
    }

    void Update()
    {
        if (enableRemove.isOn) isRemoveMode = true; else isRemoveMode = false;

        if(Input.GetKeyDown(KeyCode.I) && !inventoryUI.activeSelf && !DialogueManager.instance.dialogueIsPlaying)
        {
            inventoryUI.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Escape) && inventoryUI.activeSelf)
        {
            inventoryUI.SetActive(false);
        }
    }

    public void LoadData(GameData data)
    {
        // InventoryItems = data.InventoryItems;
    }
    
    public void SaveData(GameData data)
    {
        data.InventoryItems = InventoryItems;
    }

    private void setupItem()
    {
        foreach (var item in InventoryItems)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
        
            obj.GetComponent<InventoryItemController>().SetItem(item);
            itemInInventory.Add(obj.GetComponent<InventoryItemController>());

        }
    }
    
    public void Add(Item item)
    {
        // Check if the item is already in the inventory
        // Item existingItem = InventoryItems.Find(i => i.id == item.id);
         // if(item.quantity == 0)
        // if (existingItem != null)
        // {
            // If it exists, increase its quantity and update the UI
            // InventoryItems.Add(item);
            // GameObject obj = Instantiate(inventoryItem, itemContent);
            // item.quantity+=1;
                foreach (var items in itemInInventory)
            {
                if(items.item == item)
                {
                    item.quantity+=1;
                    items.SetItem(item);
                }
            }

            // obj.GetComponent<InventoryItemController>().SetItem(item);
            // itemInInventory.Add(obj.GetComponent<InventoryItemController>());
            
            // UpdateQuantityText(existingItem);
        // }
        // else
        // {
            // If it doesn't exist, add it to the inventory
            // InventoryItems.Add(item);
            // GameObject obj = Instantiate(inventoryItem, itemContent);
        //     foreach (var items in itemInInventory)
        //     {
        //         if(items.item == item)
        //         {
        //             item.quantity++;
        //         items.SetItem(item);
        //         }
        //     }
            
        // }
    }

    public void EnableItemsRemove()
    {
        if (enableRemove.isOn)
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
    public void Remove(Item item)
    {
        // Check if the item exists in the inventory
        Item existingItem = InventoryItems.Find(i => i.id == item.id);

        if (existingItem != null)
        {
            if (existingItem.quantity > 1)
            {
                // If the quantity is greater than 1, decrease it and update the UI
                existingItem.quantity--;
                // InventoryItems.Remove(item);
                // UpdateQuantityText(existingItem);
            }
            // else
            // {
            //     itemInInventory.Remove()
            //     // If the quantity is 1, remove the item from the inventory
            //     InventoryItems.Remove(existingItem);
            //     // InventoryItems.Remove(item);
            // }
        }
    }
    // public void UpdateQuantityText(Item item)
    // {
    //     InventoryItemController itemController = GetItemControllerByItem(item);
    //     if (itemController != null)
    //     {
    //         itemController.UpdateQuantityText();
    //     }
    // }

    // Helper method to find the InventoryItemController associated with an item
    InventoryItemController GetItemControllerByItem(Item item)
    {
        foreach (Transform itemTransform in itemContent)
        {
            InventoryItemController itemController = itemTransform.GetComponent<InventoryItemController>();
            if (itemController != null && itemController.GetItem() == item)
            {
                return itemController;
            }
        }
        return null;
    }

    // private void UpdateInventoryUI()
    // {
    //     bool isInstantiate = false;
    //     foreach (Item item in InventoryItems)
    //     {
    //         if(item.quantity > 0)
    //         {
    //         // Check if the item is already in the inventory
    //         // Item existingItem = InventoryItems.Find(i => i.id == item.id);

    //         // if (existingItem != null)
    //         // {
    //         //     if(!isInstantiate)
    //         //     {
    //                 GameObject obj = Instantiate(inventoryItem, itemContent);
    //                 obj.GetComponent<InventoryItemController>().SetItem(item);
    //                 itemInInventory.Add(obj.GetComponent<InventoryItemController>());
    //                 // existingItem.quantity -=1;
    //                 isInstantiate = true;
    //             // }    ;
    //             // UpdateQuantityText(existingItem);
    //         }
    //     }
    // }
}