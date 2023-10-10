using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public StoryScene currentScene;
    public BottomBarController bottomBar;
    public GameObject dialogueBox;
    public GameObject keyText;
    bool playerDetected;
    
    void Start()
    {
        bottomBar.PlayScene(currentScene);
    }

    void Update()
    {
        if(playerDetected && Input.GetKeyDown(KeyCode.E))
        {
            keyText.SetActive(false);
            dialogueBox.SetActive(true);
            bottomBar.PlayScene(currentScene);
        }

        if(Input.GetKeyDown(KeyCode.Space) && dialogueBox.activeSelf)
        {
            if(bottomBar.IsCompleted())
            {
                if(bottomBar.IsLastSentence())
                {
                    bottomBar.StartOver();
                    dialogueBox.SetActive(false);
                    keyText.SetActive(true);
                }
                bottomBar.PlayNextSentence();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if(!dialogueBox.activeSelf)
            {
                keyText.SetActive(true);
            }
            playerDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        playerDetected = false;
        keyText.SetActive(false);
    }

}
