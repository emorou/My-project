using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    DialogueSystem dialogue;
    public string[] sentences;
    // Start is called before the first frame update
    void Start()
    {
        dialogue = DialogueSystem.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
