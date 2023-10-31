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

    private Button saveSlotButton;

    [Header("Clear Data Button")]
    [SerializeField] private Button clearButton;

    private void Awake()
    {
        saveSlotButton = this.GetComponent<Button>();
    }

    public void SetData(GameData data)
    {
        if(data == null)
        {
            noDataContent.SetActive(true);
            hasDataContent.SetActive(false);
            clearButton.gameObject.SetActive(true;)
        }
        else
        {
            noDataContent.SetActive(false);
            hasDataContent.SetActive(true);
            levelText.text = "Level : " + data.level;
        }
    }

    public string GetProfileId()
    {
        return this.profileId;
    }

    public void SetInteractable(bool interactable)
    {
        saveSlotButton.interactable = interactable;
    }
}