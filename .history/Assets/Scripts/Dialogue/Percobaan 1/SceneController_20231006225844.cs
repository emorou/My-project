using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public StoryScene currentScene;
    public BottomBarController bottomBar;
    public GameObject dialogueBox;
    public GameObject keyText;
    bool playerDetected;

    public GameObject CelticPrefab;
    public GameObject npcPrefab;
    public float darkenAmount = 0.5f;

    void Update()
    {
        if(bottomBar.sentenceIndex % 2 != 0)
        {
            // Instantiate(speaker.characterPrefab, npcPosition.transform.position, Quaternion.identity);
            Image imageComponent = CelticPrefab.GetComponent<Image>();
            Color tmp = imageComponent.color;
            tmp.r = 0.5f;
            tmp.g = 0.5f;
            tmp.b = 0.5f;
            imageComponent.color = tmp;

            Image npcComponent = npcPrefab.GetComponent<Image>();
            Color tmp1 = npcComponent.color;
            tmp1.r = 1.0f;
            tmp1.g = 1.0f;
            tmp1.b = 1.0f;
            imageComponent.color = tmp1;
        }
        else
        {
            // Instantiate(speaker.characterPrefab, celticPosition.transform.position, Quaternion.identity);

        }

        if(playerDetected && Input.GetKeyDown(KeyCode.E) && !dialogueBox.activeSelf)
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
