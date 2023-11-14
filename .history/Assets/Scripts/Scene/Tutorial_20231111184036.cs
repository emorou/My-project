using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorialSlide;
    public GameObject panel;

    public static Tutorial instance;

    void Awake()
    {
        instance = this;
    }

    void Start() 
    {
        tutorialSlide.SetActive(false);
    }

    void Update()
    {

        if(panel.activeSelf && Input.GetMouseButtonDown(0) | Input.GetKeyDown(KeyCode.Escape) && !DialogueManager.instance.dialogueIsPlaying)
        {
            panel.SetActive(false);
        }

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            panel.SetActive(true);
            tutorialSlide.SetActive(true);
        }
    }
}
