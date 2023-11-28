using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorialSlide1;
    public GameObject tutorialSlide2;
    public GameObject tutorialSlide3;
    public GameObject warpGate1;
    public GameObject warpGate2;

    public bool slide1Done = false;
    public bool slide2Done = false;
    public bool slide3Done = false;
    public bool isWPressed = false;
    public bool isAPressed = false;
    public bool isSPressed = false;
    public bool isDPressed = false;
    
    [SerializeField] private TextAsset inkJSON1;

    public static Tutorial instance;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        

        void SafeZoneTutorial()
        {
            
        }
    }
}
