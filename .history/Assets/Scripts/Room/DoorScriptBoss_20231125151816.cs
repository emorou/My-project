using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScriptBoss : MonoBehaviour
{
    [SerializeField] Transform posToGo;
    [SerializeField] GameObject keyTxt;
    [SerializeField] private EnemySpawnerBoss enemySpawnerBoss;
    bool playerDetected;
    GameObject playerGO;
    
    // Start is called before the first frame update
    void Start()
    {
        playerDetected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDetected)
        {
            if (Input.GetKeyDown(KeyCode.E) && enemySpawner.ableToTeleport)
            {
                enemySpawner.ableToTeleport = false;
                playerGO.transform.position = posToGo.position;
                playerDetected = false;
            }
        }
    }

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
