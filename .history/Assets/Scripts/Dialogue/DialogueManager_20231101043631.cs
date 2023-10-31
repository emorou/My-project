using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private 
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
