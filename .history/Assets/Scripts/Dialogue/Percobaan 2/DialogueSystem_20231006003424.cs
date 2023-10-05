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
    
    void Awake()
    {
        instance = this;    
    }

    public void Say()
    {
        StopSpeaking();
        speaking = 
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
