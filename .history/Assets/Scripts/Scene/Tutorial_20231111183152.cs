using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorialSlide;
    public GameObject panel;

    public static Tutorial instance;
    void Awake()
    {
        instance = this;
    }
    void Update()
    {
        tutorialText.text = "";

        if(panel.activeSelf && Input.GetMouseButtonDown(0) && !DialogueManager.instance.dialogueIsPlaying)
        {
            panel.SetActive(false);
        }

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            panel.SetActive(true);
            tutorialText.text = "Pencet Klik kiri dan klik kanan";
        }
    }
}
