 using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public List<Item> Items = new List<Item>();

    private void Awake()
    {
        instance = this;
    }

    public void Add(Item item)
    {
        Items.Add()
    }
}
