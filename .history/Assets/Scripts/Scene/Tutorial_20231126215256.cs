using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [Header("Safe Zone Tutorial")]
    public GameObject tutorialSlide1;
    public GameObject tutorialSlide2;
    public GameObject tutorialSlide3;
    public GameObject warpGate1;
    public bool slide1Done = false;
    public bool slide2Done = false;
    public bool slide3Done = false;
    public bool isWPressed = false;
    public bool isAPressed = false;
    public bool isSPressed = false;
    public bool isDPressed = false;
    public bool isSafeZoneTutorialDone = false;
    [SerializeField] private TextAsset inkJSON1;

    [Header("Chamber 1 Tutorial")]
    public GameObject tutorialSlide4;
    public GameObject crateBox;
    public bool slide4Done = false;
    public GameObject warpGate2;
    public bool isChamber1TutorialDone = false;
    [SerializeField] private TextAsset inkJSON2;

    public static Tutorial instance;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        SafeZoneTutorial();

        if(isSafeZoneTutorialDone)
        {
            Chamber1Tutorial();
        }
    }

    void SafeZoneTutorial()
    {
        if(DialogueManager.instance.dialogueIsPlaying)
        {
            if(!slide1Done)
            {
              tutorialSlide1.SetActive(false);  
            }
            else if(slide1Done && !slide2Done)
            {
               tutorialSlide2.SetActive(false); 
            }
            else if(!slide3Done && slide2Done)
            {
               tutorialSlide3.SetActive(false); 
            }
        }
        if(!slide1Done && !DialogueManager.instance.dialogueIsPlaying)
        {
            tutorialSlide1.SetActive(true);
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
    
        if(slide1Done && !slide2Done && !DialogueManager.instance.dialogueIsPlaying)
        {
            tutorialSlide2.SetActive(true);
            if(Input.GetMouseButtonDown(0))
            {
                tutorialSlide2.SetActive(false);
                tutorialSlide3.SetActive(true);
                slide2Done = true;
            }
        }
        
        if(slide2Done && Input.GetMouseButtonDown(1) && !slide3Done && !DialogueManager.instance.dialogueIsPlaying)
        {
            tutorialSlide3.SetActive(true);
            if(Input.GetMouseButtonDown(1))
            {
                tutorialSlide3.SetActive(false);
                slide3Done = true;
                warpGate1.SetActive(true);
                DialogueManager.instance.EnterDialogueMode(inkJSON1);
                DialogueManager.instance.dialogueIsPlaying = true;
                DialogueManager.instance.dialoguePanel.SetActive(true);
            }
        }
    }

    void Chamber1Tutorial()
    {
        tutorialSlide4.SetActive(true);

        if(crateBox == )
        {
            isChamber1TutorialDone = true;
            warpGate2.SetActive(true);
            DialogueManager.instance.EnterDialogueMode(inkJSON2);
            DialogueManager.instance.dialogueIsPlaying = true;
            DialogueManager.instance.dialoguePanel.SetActive(true);
        }

        if(DialogueManager.instance.dialogueIsPlaying)
        {
            tutorialSlide4.SetActive(false);
        }
    }
}
