using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorialSlide1;
    public GameObject tutorialSlide2;
    public GameObject panel;

    public bool slide1Done;
    public bool slide2Done;
    public static Tutorial instance;

    void Awake()
    {
        slide1Done = false;
        slide2Done = false;
        instance = this;
    }

    void Update()
    {
        if(panel.activeSelf && Input.GetMouseButtonDown(0) && !DialogueManager.instance.dialogueIsPlaying)
        {
            panel.SetActive(false);
            tutorialSlide1.SetActive(false);
        }
    
        if(Input.GetKeyDown(KeyCode.W) && !slide1Done && !tutorialSlide1.activeSelf)
        {
            panel.SetActive(true);
            tutorialSlide1.SetActive(false);
            tutorialSlide2.SetActive(true);
            slide1Done = true;
        }

        if(slide1Done && Input.GetMouseButtonDown(0) && !tutorialSlide2.activeSelf && !slide2Done)
        {
            panel.SetActive(true);
            tutorialSlide2.SetActive(false);
            slide2Done = true;
        }
        
    }
}
