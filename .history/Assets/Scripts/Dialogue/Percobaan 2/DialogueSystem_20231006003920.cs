using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class DialogueSystem : MonoBehaviour
{
    public DialogueSystem instance;
    public Elements elements;
    
    public bool isSpeaking {get{return speaking != null}}
    Coroutine speaking = null;
    public bool isWaitingForUserInput = false;

    void Awake()
    {
        instance = this;    
    }

    public void Say(string speech, string speaker)
    {
        StopSpeaking();
        speaking = StartCoroutine(Speaking(speech, speaker));
    }

    public void StopSpeaking()
    {
        if (isSpeaking)
        {
            StopCoroutine(speaking);
        }
        speaking = null;
    }
    IEnumerator Speaking(string targetSpeech, string speaker)
    {
        speechPanel.SetActive(true);
        speechText.text = "";
        speakerName.text = speaker;
        isWaitingForUserInput = false;
        
        while(speechText.text != targetSpeech)
        {
            speechText.text += targetSpeech[speechText.text.Length-1];
            yield return new WaitForEndOfFrame();
        }

        while(isWaitingForUserInput)
        {
            
        }
    }

    [System.Serializable]
    public class Elements
    {
        public GameObject speechPanel;
        public Text speakerName;
        public Text speechText;
    }

    public GameObject speechPanel {get{return elements.speechPanel;}}
    public Text speakerName {get{return elements.speakerName;}}
    public Text speechText {get{return elements.speechText;}}
}
