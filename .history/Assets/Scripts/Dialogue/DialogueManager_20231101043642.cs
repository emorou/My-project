using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text 
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
