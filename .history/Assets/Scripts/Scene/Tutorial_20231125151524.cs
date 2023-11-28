using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour, IDataPersistence
{
    public GameObject tutorialSlide1;
    public GameObject tutorialSlide2;
    public GameObject tutorialSlide3;
    public GameObject warpGate;

    public bool slide1Done = false;
    public bool slide2Done = false;
    public bool slide3Done = false;
    public bool isWPressed = false;
    public bool isAPressed = false;
    public bool isSPressed = false;
    public bool isDPressed = false;
    
    public static Tutorial instance;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if(!slide1Done && !DialogueManager.instance.dialogueIsPlaying)
        {
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
            warpGate.SetActive(true);
        }

        if(boss == null)
        {
            Time.timeScale = 0f;
            tutorialDoneSlide.SetActive(true);
        }
    }

    public void SaveData(GameData data)
    {
        data.tutorialDone = true;
    }

    public void LoadData(GameData data)
    {
        data.tutorialDone = false;
    }
}
