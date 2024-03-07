using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject pauseScreen;
    public static Pause instance;
    // Update is called once per frame

    private void Awake()
    {
        
        instance = this;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !DialogueManager.instance.dialogueIsPlaying && !InventoryManager.instance.inventoryUI.activeSelf)
        {
            if (GameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    public void PauseGame()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ResumeForButton()
    {
        GameIsPaused = 
        Time.timeScale = 1f;
    }

    public void PauseForButton()
    {
        Time.timeScale = 0f;
    }
}