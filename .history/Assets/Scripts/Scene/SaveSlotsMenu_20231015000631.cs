using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSlotsMenu : MonoBehaviour
{
    private SaveSlot[] saveSlots;

    private void Awake()
    {
        saveSlots = this.GetComponentsInChildren<SaveSlot>();
    }

    public void ActivateMenu()
    {
        Dictionary<string,GameData> profilesGameData = DataPersistenceManager.instance.GetAllProfileGamesData();
    }
}
