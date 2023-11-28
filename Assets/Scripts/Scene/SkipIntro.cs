using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkipIntro : MonoBehaviour
{
    public void ToMainMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync("Main Menu");
        }
    }
}
