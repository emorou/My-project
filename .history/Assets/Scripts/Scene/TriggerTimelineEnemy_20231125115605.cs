using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTimelineEnemy : MonoBehaviour
{
    [SerializeField] private TimelineEnemy timelineEnemy;
     private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            timelineEnemy.EnemyStart();
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
