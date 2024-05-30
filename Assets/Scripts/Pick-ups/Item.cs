using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

[CreateAssetMenu(fileName = "New  Item", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    [SerializeField] public int id;
    [SerializeField] public string itemName;
    [SerializeField] public int value;
    [SerializeField] public Sprite itemIcon;
    [SerializeField] public ItemType itemType;
    [SerializeField] public int quantity;
    [SerializeField] public int itemCost;
    public enum ItemType
    {
        Potion,
        Ammo
    }
}
