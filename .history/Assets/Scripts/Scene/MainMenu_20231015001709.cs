using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Menu Navigation")]
    [SerializeField] private SaveSlotsMenu saveSlotsMenu;

    [Header("Menu Buttons")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueGameButton;

    private void Start() 
    {
        if (!DataPersistenceManager.instance.HasGameData()) 
        {
            continueGameButton.interactable = false;
        }
    }

    public void OnNewGameClicked() 
    {
        saveSlotsMenu.ActivateMenu();
        this.DeactivateMenu();
    }

    public void OnContinueGameClicked() 
    {
        DisableMenuButtons();
        // load the next scene - which will in turn load the game because of 
        // OnSceneLoaded() in the DataPersistenceManager
        SceneManager.LoadSceneAsync("Lobby");
    }

    private void DisableMenuButtons() 
    {
        newGameButton.interactable = false;
        continueGameButton.interactable = false;
    }

    public void ActivateMenu()
    {
        
    }

    public void DeactivateMenu()
    {

    }
}