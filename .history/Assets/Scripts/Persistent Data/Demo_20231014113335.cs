using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data.Common;
using System;

public class Demo : MonoBehaviour
{
    [SerializeField]
    private TMP_Text sourceDataText;
    [SerializeField]
    private TMP_InputField InputField;
    [SerializeField]
    private TMP_Text saveTimeText;
    [SerializeField]
    private TMP_Text LoadTimeText;

    private PlayerStats playerStats = new PlayerStats();
    private IDataServices dataService = new JsonDataService();
    private bool EncryptionEnabled;
    private long saveTime;

    public void ToggleEncryption(bool EncryptionEnabled)
    {
        this.EncryptionEnabled = EncryptionEnabled; 
    }

    public void SerializeJson()
    {
        long startTime = DateTime.Now.Ticks;
        if(dataService.SaveData("/player-stats.json", playerStats, EncryptionEnabled))
        {
            saveTime = DateTime.Now.Ticks - startTime;
            saveTimeText.SetText($"Save Time: {(saveTime / 10000f) : N4}ms");
        }
        else
        {
            Debug.LogError("eror");
            InputField.text = "eror saving data";
        }
    }

    private void Awake()
    {
        sourceDataText.SetText(JsonConvert.)
    }
}
