// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;

// public class MainMenu : MonoBehaviour
// {
//     [Header("Menu Buttons")]

//     [SerializeField] private Button newGameButton;

//     [SerializeField] private Button continueGameButton;

//     private void Start()
//     {
//         if(!DataPersistenceManager.instance.HasGameData())
//         {
//             continueGameButton.interactable = false;
//         }
//     }
//     public void OnNewGameClicked()
//     {
//         DisableMenuButtons();
//         DataPersistenceManager.instance.NewGame();
//         SceneManager.LoadSceneAsync("Lobby");
//     }

//     public void OnContinueGameClicked()
//     {
//         DisableMenuButtons();
//         DataPersistenceManager.instance.SaveGame();
//         SceneManager.LoadSceneAsync("Lobby");
//     }

//     private void DisableMenuButtons()
//     {
//         newGameButton.interactable = false;
//         continueGameButton.interactable = false; 
//     }
// }

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
        if (!DataPersistenceManager.instance.HasGameData()) 
        {
            continueGameButton.interactable = false;
        }
    }

    public void OnNewGameClicked() 
    {
        DisableMenuButtons();
        // create a new game - which will initialize our game data
        DataPersistenceManager.instance.NewGame();
        // load the gameplay scene - which will in turn save the game because of
        // OnSceneUnloaded() in the DataPersistenceManager
        SceneManager.LoadSceneAsync("Lobby");
    }

    public void OnContinueGameClicked() 
    {
        DisableMenuButtons();
        // load the next scene - which will in turn load the game because of 
        // OnSceneLoaded() in the DataPersistenceManager
        SceneManager.LoadSceneAsync("SampleScene");
    }

    private void DisableMenuButtons() 
    {
        newGameButton.interactable = false;
        continueGameButton.interactable = false;
    }
}