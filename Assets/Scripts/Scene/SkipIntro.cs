using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkipIntro : MonoBehaviour
{
    public void ToMainMenu()
    {
        LevelLoader.instance.NextLevel(1);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            LevelLoader.instance.NextLevel(1);
        }
    }
}
