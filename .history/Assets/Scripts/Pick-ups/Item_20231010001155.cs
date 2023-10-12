using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObjects/")]
public class Item : MonoBehaviour
{
    public int id;
    public string itemName;
    public int value;
    public Sprite icon;
}