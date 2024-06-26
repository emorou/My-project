using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InvisibleDialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    public bool isDialogueDone = false;

    private void  OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && isDialogueDone)
        {
            DialogueManager.instance.EnterDialogueMode(inkJSON);
            isDialogueDone = true;
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
