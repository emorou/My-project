using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Menu Buttons")]

    [SerializeField] private Button newGameButton;

    [SerializeField] private Button continueGameButton;

    private void Start()
    {
        if(!DataPersistenceManager.instance.HasGameData())
        {
            continueGameButton.interactable = false;
        }
    }
    public void OnNewGameClicked()
    {
        DisableMenuButtons();
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadSceneAsync("Lobby");
    }

    public void OnContinueGameClicked()
    {
        DisableMenuButtons();
        DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadSceneAsync("Lobby");
    }

    private void DisableMenuButtons()
    {
        newGameButton.interactable = false;
        continueGameButton.interactable = false; 
    }
}
