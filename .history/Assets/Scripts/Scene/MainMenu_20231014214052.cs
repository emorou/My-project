using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnNewGameClicked()
    {
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadSceneAsync("SampleScene")
    }

    public void OnContinueGameClicked()
    {
          
    }
}
