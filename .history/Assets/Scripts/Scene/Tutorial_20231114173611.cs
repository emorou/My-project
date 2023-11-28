using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorialSlide1;
    public GameObject tutorialSlide2;
    public GameObject tutorialSlide3;
    public GameObject panel;

    public bool slide1Done = false;
    public bool slide2Done = false;
    public bool slide3Done = false;

    public static Tutorial instance;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if(!slide1Done && !DialogueManager.instance.dialogueIsPlaying )
        {
            tutorialSlide1.SetActive(false);
            tutorialSlide2.SetActive(true);
            slide1Done = true;
        }

        if(slide1Done && Input.GetMouseButtonDown(0) && !slide2Done)
        {
            tutorialSlide2.SetActive(false);
            tutorialSlide3.SetActive(true);
            slide2Done = true;
        }
        
        if(slide2Done && Input.GetMouseButtonDown(1) && !slide3Done)
        {
            tutorialSlide3.SetActive(false);
            slide3Done = true;
        }

    }

    void Slide1Tutorial()
    {
        bool isWPressed = false;
        bool isAPressed = false;
        bool isSPressed = false;
        bool isDPressed = false;

        if(Input.GetKeyDown(KeyCode.W))
        {
            isWPressed = true;
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            isAPressed = true;
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            isSPressed = true;
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            isDPressed = true;
        }

        if(isWPressed && isAPressed && isSPressed && isDPressed)
        {
            tutorialSlide1.SetActive(false);
            tutorialSlide2.SetActive(true);
            slide1Done = true;
        }
    }

    void Slide2Tutorial()
    {
        if(slide1Done && Input.GetMouseButtonDown(0) && !slide2Done)
        {
            tutorialSlide2.SetActive(false);
            tutorialSlide3.SetActive(true);
            slide2Done = true;
        }
    }

    void Slide3Tutorial()
    {
        if(slide2Done && Input.GetMouseButtonDown(1) && !slide3Done)
        {
            tutorialSlide3.SetActive(false);
            slide3Done = true;
        }   
    }
}
