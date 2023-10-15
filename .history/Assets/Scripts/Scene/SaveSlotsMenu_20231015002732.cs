using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine;
public class SaveSlotsMenu : MonoBehaviour
{
    [Header("Menu Navigation")]
    [SerializeField] private MainMenu mainMenu;

    private SaveSlot[] saveSlots;

    private void Awake()
    {
        saveSlots = this.GetComponentsInChildren<SaveSlot>();
    }
    
    public void OnSaveSlotClicked(SaveSlot saveSlot)
    {
        DisableMenuButtons();
        DataPersistenceManager.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());

        DataPersistenceManager.instance.NewGame(); 
        
        SceneManager.LoadSceneAsync("Lobby");
    }

    public void OnBackClicked()
    {
        mainMenu.ActivateMenu();
        this.DeactivateMenu();
    }
    public void ActivateMenu()
    {
        this.gameObject.SetActive(true);

        Dictionary<string,GameData> profilesGameData = DataPersistenceManager.instance.GetAllProfileGamesData(); 

        foreach (SaveSlot saveSlot in saveSlots)
        {
            GameData profileData = null;
            profilesGameData.TryGetValue(saveSlot.GetProfileId(), out profileData);
            saveSlot.SetData(profileData);
        }
    }

    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }

    private void DisableMenuButtons()
    {
        foreach (SaveSlot saveSlot in saveSlots)
        {
            saveSlot.SetInteractable(false);
        }
    }
}
