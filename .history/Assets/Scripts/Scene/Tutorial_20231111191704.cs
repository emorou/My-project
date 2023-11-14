using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorialSlide1;
    public GameObject tutorialSlide2;
    public GameObject panel;

    public bool slide2Done;
    public static Tutorial instance;

    void Awake()
    {
        slide2Done = false;
        instance = this;
    }

    void Update()
    {
        if(panel.activeSelf && Input.GetMouseButtonDown(0) && !DialogueManager.instance.dialogueIsPlaying)
        {
            panel.SetActive(false);
        }
    
        if(Input.GetKeyDown(KeyCode.W))
        {
            panel.SetActive(true);
            tutorialSlide1.SetActive(false);
            tutorialSlide2.SetActive(true);
        }

        if(!panel.activeSelf && Input.GetMouseButtonDown(0))
        {
            tutorialSlide3.SetActive(true);
        }
        
    }
}
