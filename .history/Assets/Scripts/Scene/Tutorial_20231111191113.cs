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
            tutorialSlide1.SetActive(false);
            if(slide2Done)
            {
                
            }
            tutorialSlide2.SetActive(false);
        }
    
        if(Input.GetKeyDown(KeyCode.W) && !slide2Done)
        {
            panel.SetActive(true);
            tutorialSlide2.SetActive(true);
            slide2Done = true;
        }
    }
}
