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
    public bool slide2Done = false;4
    public static Tutorial instance;

    void Awake()
    {
        slide1Done = false;
        slide2Done = false;
        instance = this;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && !slide1Done)
        {
            tutorialSlide1.SetActive(false);
            tutorialSlide2.SetActive(true);
            slide1Done = true;
        }

        if(slide1Done && Input.GetMouseButtonDown(0) && !slide2Done)
        {
            tutorialSlide2.SetActive(false);
            slide2Done = true;
        }
        
        if(slide2Done && Input.GetMouseButtonDown(1) && !slide3Done)
        {
            tutorialSlide2.SetActive(false);
            slide2Done = true;
        }

    }
}
