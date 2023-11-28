using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InvisibleDialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    public bool 
    private void  OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            DialogueManager.instance.EnterDialogueMode(inkJSON);
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
