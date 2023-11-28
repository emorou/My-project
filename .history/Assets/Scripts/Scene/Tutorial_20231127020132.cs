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
    public GameObject warpGate3;
    public bool isChamber1TutorialDone = false;
    [SerializeField] private TextAsset inkJSON2;

    [Header("Chamber 2 Tutorial")]
    public GameObject tutorialSlide5;
    public GameObject tutorialSlide6;
    public GameObject enemiesChamber2;
    public bool slide5Done = false;
    public bool slide6Done = false;
    public GameObject warpGate4;
    public GameObject warpGate5;
    public bool isChamber2TutorialDone = false;
    [SerializeField] private TextAsset inkJSON3;
    [SerializeField] private TextAsset inkJSON4;

    [Header("Chamber 3 Tutorial")]
    public GameObject tutorialSlide7;
    public GameObject warpGate6;
    public GameObject boss;
    public bool isEnterBossRoom = false;
    public bool isBossTutorialDone = false;
    [SerializeField] private TextAsset inkJSON5;

    public GameObject tutorialDone;

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

        if(isChamber1TutorialDone)
        {
            Chamber2Tutorial();
        }

        if(isEnterBossRoom)
        {
            BossRoomTutorial();
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
        if(!DialogueManager.instance.dialogueIsPlaying && !slide4Done)
        {
            tutorialSlide4.SetActive(true);  
        }

        Transform childCrateBox = crateBox.transform.Find("Ammo & Health");

        if(childCrateBox == null && !slide4Done && !DialogueManager.instance.dialogueIsPlaying)
        {
            slide4Done = true;
            tutorialSlide4.SetActive(false);
            warpGate2.SetActive(true);
            warpGate3.SetActive(true);
            DialogueManager.instance.EnterDialogueMode(inkJSON2);
            DialogueManager.instance.dialogueIsPlaying = true;
            DialogueManager.instance.dialoguePanel.SetActive(true);
        }

        if(DialogueManager.instance.dialogueIsPlaying)
        {
            tutorialSlide4.SetActive(false);
        }
    }

    void Chamber2Tutorial()
    {
        Transform enemy1 = enemiesChamber2.transform.Find("enemy 1");
        Transform enemy2 = enemiesChamber2.transform.Find("enemy 2");
        Transform enemy3 = enemiesChamber2.transform.Find("enemy 3");

        if(!slide5Done && !DialogueManager.instance.dialogueIsPlaying)
        {
            tutorialSlide5.SetActive(true);  
            enemiesChamber2.SetActive(true);
            if(enemy1 == null && enemy2 == null && enemy3 == null)
            {
                slide5Done = true;
                DialogueManager.instance.EnterDialogueMode(inkJSON4);
                DialogueManager.instance.dialogueIsPlaying = true;
                DialogueManager.instance.dialoguePanel.SetActive(true);
            }
        }

        if(slide5Done && !DialogueManager.instance.dialogueIsPlaying && !slide6Done)
        {
            tutorialSlide6.SetActive(true);
            if(InventoryManager.instance.inventoryUI.activeSelf)
            {
                slide6Done = true;
                tutorialSlide6.SetActive(false);
            }
        }

        if(DialogueManager.instance.dialogueIsPlaying)
        {
            tutorialSlide5.SetActive(false);
            tutorialSlide6.SetActive(false);
        }

        if(slide6Done)
        {
            warpGate4.SetActive(true);
            warpGate5.SetActive(true);
            isChamber2TutorialDone = true;
        }
    }

    void BossRoomTutorial()
    {
        boss.se
        Transform bossOgre = boss.transform.Find("Ogre");
        warpGate6.SetActive(false);
        if(bossOgre == null)
        {
            DialogueManager.instance.EnterDialogueMode(inkJSON5);
            DialogueManager.instance.dialogueIsPlaying = true;
            DialogueManager.instance.dialoguePanel.SetActive(true);
        }
    }
}
