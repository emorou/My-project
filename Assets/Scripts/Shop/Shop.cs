using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Shop : MonoBehaviour
{
    public Item item;
     public List<Item> InventoryItems = new List<Item>();

    public int goldCost;
    public TMP_Text goldCostText;

    // Start is called before the first frame update
    public void Buy()
    {
        if(PlayerStats.Instance.gold >= goldCost)
        {
            InventoryManager.instance.Add(item);
            PlayerStats.Instance.gold -= goldCost;
        }
        else
        {
            ShopManager.Instance.ShowWarningSign();
        }
    }

    public void Start()
    {
        goldCostText.text = goldCost.ToString();
    }
}
