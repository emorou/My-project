using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    DialogueSystem dialogue;
    public string[] sentences;
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = DialogueSystem.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(!dialogue.isSpeaking || dialogue.isWaitingForUserInput)
            {
                if(index >= sentences.Length)
                {
                    Say[sentences[index]];
                    index++;
                }
            }
        }
    }

    void Say(string s)
    {
        string[] parts = s.Split(':');
        string speech = parts[0];
        string speaker = (parts.Length >= 2) ? parts
    }
}
