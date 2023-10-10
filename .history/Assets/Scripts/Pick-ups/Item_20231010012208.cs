using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

[CreateAssetMenu(fileName = "New  Item", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public Sprite itemicon;

    public enum ItemType
    {
        
    }
}
