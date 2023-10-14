using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data.Common;

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

    public void ToggleEncryption(bool EncryptionEnabled)
    {
        this.EncryptionEnabled = EncryptionEnabled; 
    }

    public void SerializeJson()
    {
        if(dataService.SaveData("/player-stats.json", playerStats, EncryptionEnabled))
        {
            
        }
    }
}
