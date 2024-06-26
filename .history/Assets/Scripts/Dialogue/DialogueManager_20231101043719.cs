using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;

    private Story currentStory;

    private bool dialogueIsPlaying;
    private static DialogueManager instance;

    private void Awake()
    {

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
