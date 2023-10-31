using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour
{
    [Header("Profile")]
    [SerializeField] private string profileId = ""; 

    [Header("Content")]

    [SerializeField] private GameObject noDataContent;
    [SerializeField] private GameObject hasDataContent;
    [SerializeField] private TMP_Text levelText;

    private PlayerStats playerStats;

    private Button saveSlotButton;

    
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }
    public void SetData(GameData data)
    {
        if(data == null)
        {
            noDataContent.SetActive(true);
            hasDataContent.SetActive(false);
        }
        else
        {
            noDataContent.SetActive(false);
            hasDataContent.SetActive(true);
            levelText.text = "Level : " + playerStats.level;
        }
    }

    public string GetProfileId()
    {
        return this.profileId;
    }
}