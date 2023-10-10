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
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;    
    }

    [System.Serializable]
    public class Elements
    {
        public GameObject speechPanel;
        public Text speakerName;
        public Text speechText;
    }

    public GameObject speechPanel {get{return elements.speechPanel;}}
    public GameObject speechPanel {get{return elements.speechPanel;}}
}
