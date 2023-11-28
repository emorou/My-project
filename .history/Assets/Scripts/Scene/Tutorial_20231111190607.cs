using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorialSlide1;
    public GameObject tutorialSlide2;
    public GameObject panel;

    public static Tutorial instance;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {

        if(panel.activeSelf && Input.GetMouseButtonDown(0) && !DialogueManager.instance.dialogueIsPlaying)
        {
            panel.SetActive(false);
            tutorialSlide1.SetActive(false);
            tutorialSlide2.SetActive(false);
        }

        Event d = Event.current;
        Event w = Event.current;
        Event a = Event.current;
        Event w = Event.current
        if(w.isKey && a.isKey && s.isKey && d.isKey)
        {
            panel.SetActive(true);
            tutorialSlide2.SetActive(true);
        }
    }
}
