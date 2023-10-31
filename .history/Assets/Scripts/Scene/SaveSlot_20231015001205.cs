using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveSlot : MonoBehaviour
{
    [Header("Profile")]
    [SerializeField] private string profileId = ""; 

    [Header("Content")]

    [SerializeField] private GameObject noDataContent;
    [SerializeField] private GameObject hasDataContent;
    [SerializeField] private TMP_Text levelText;
    
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
        }
        levelText.text = "Level : " + playerStats.level;
    }

    public string GetProfileId()
    {
        return this.profileId;
    }

    internal void SetData(GameData profileData)
    {
        throw new NotImplementedException();
    }
}