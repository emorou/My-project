using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public GameObject shop;
    private bool playerInRange;
    [SerializeField] private GameObject visualCue;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }
    private void Update()
    {
        if(playerInRange && !DialogueManager.instance.dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if(Input.GetKeyDown(KeyCode.F))
            {
                shop.SetActive(true);
            }
            
        } 
        else if(Input.GetKeyDown(KeyCode.Escape) && shop.activeSelf)
        {
            shop.SetActive(false);
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
