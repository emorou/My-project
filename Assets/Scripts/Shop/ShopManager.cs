using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopManager : MonoBehaviour
{
    public Item[] items;
    public ShopTemplate[] shopPanels;
    public static ShopManager Instance;
    public Button[] purchaseButton;
    public GameObject shopUI;
    public bool isShopAppear;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        LoadItems();
        CheckPurchaseable();
    }

    public void Update()
    {
        if(shopUI.activeSelf)
        {
            isShopAppear = true;
        }
        else
        {
            isShopAppear = false;
        }
    }
    public void LoadItems()
    {
        for (int i = 0; i < items.Length; i++)
        {
            shopPanels[i].titleText.text = items[i].itemName;
            shopPanels[i].costText.text = items[i].itemCost.ToString();
            shopPanels[i].itemIcon.sprite = items[i].itemIcon;   
        }
    }

    public void CheckPurchaseable()
    {
        // for (int i = 0; i < items.Length; i++)
        // {
        //    if(PlayerStats.Instance.gold >= items[i].itemCost)
        //     {
        //         purchaseButton[i].interactable = true;
        //     } 
        //     else
        //     {
        //         purchaseButton[i].interactable = false;
        //     }
        // }
        
    }

    public void PurchaseItem(int buttonNumber)
    {
        if (PlayerStats.Instance.gold >= items[buttonNumber].itemCost)
        {
            InventoryManager.instance.Add(items[buttonNumber]);
            PlayerStats.Instance.gold -= items[buttonNumber].itemCost;
            CheckPurchaseable();
        }
    }
}
