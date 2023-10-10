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
            var removeButton = obj.transform
            itemName.text = item.itemName;
            itemIcon.sprite = item.itemicon;
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
                item.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in itemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }   
        }
    }
}
