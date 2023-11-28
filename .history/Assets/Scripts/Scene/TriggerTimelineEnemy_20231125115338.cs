using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTimelineEnemy : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && enemySpawner.ableToTeleport)
        {
            playerDetected = true;
            playerGO = col.gameObject;
            keyTxt.SetActive(true);
            enemySpawner.SpawnEnemy();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        playerDetected = false;
        if (keyTxt != null)
        {
            keyTxt.SetActive(false);
        }
    }
}
