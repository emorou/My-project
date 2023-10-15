using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelection : MonoBehaviour
{
    bool playerDetected;
    public GameObject selectionScreen;
    public GameObject readyButton;
    public GameObject pauseScreen;

    void Start()
    {
        playerDetected = false;
    }

    void Update()
    {
        if (playerDetected)
        {
            if (Input.GetKeyDown(KeyCode.E) && !selectionScreen.activeSelf)
            {
                selectionScreen.SetActive(true);
                Time.timeScale = 0f;

            }

            if (Input.GetKeyDown(KeyCode.Escape) && selectionScreen.activeSelf)
            {
                Time.timeScale = 1f;
                playerDetected = false;
                selectionScreen.SetActive(false);
                pauseScreen.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            readyButton.SetActive(true);
            playerDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        playerDetected = false;
        if (readyButton != null)
        {
            readyButton.SetActive(false);
        }

    }
}
