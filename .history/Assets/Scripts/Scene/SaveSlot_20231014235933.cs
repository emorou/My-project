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
            
        }
        else
        {

        }
    }
}