using System.Security.Cryptography;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
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
        if(Input.GetKeyDown(KeyCode.W) && !slide1Done && !DialogueManager.instance.dialogueIsPlaying )
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
        bool isWPressed;
        bool isAPressed;
        bool isSPressed;
        bool isDPressed;
        if(Input.GetKeyDown(KeyCode.W))

       }
}
