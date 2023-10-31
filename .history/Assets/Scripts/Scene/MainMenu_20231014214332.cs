using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Menu Buttons")]

    [SerializeField]

    [SerializeField]
    
    public void OnNewGameClicked()
    {
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadSceneAsync("Lobby");
    }

    public void OnContinueGameClicked()
    {
        SceneManager.LoadSceneAsync("Lobby");
    }
}
