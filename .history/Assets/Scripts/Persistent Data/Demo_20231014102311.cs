using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public 
}
