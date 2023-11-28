using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InvisibleDialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;


    private void Update()
    {
        if(!DialogueManager.instance.dialogueIsPlaying)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                DialogueManager.instance.EnterDialogueMode(inkJSON);
            }
        }    
        else
        visualCue.SetActive(false);
    }

    private void  OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
