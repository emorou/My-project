using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    
    [Header("Ink JSON")]
    
    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update()
    {
        if(playerInRange)
        {
            visualCue.SetActive(true);
        }    
        else
        visualCue.SetActive(false);
    }

    private void  OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "player")
        {
            playerInRange = false;
        }
    }
}
