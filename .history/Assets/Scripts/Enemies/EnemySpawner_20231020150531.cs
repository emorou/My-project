using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefab;
    public List<Transform> enemySpawnPoint;
    public float spawnInterval = 2.0f;
    public float nextSpawnTime = 0.0f;
    public int currentEnemyIndex = 0;

    public GameObject entranceTrigger; // Drag and drop the entrance trigger GameObject here

    private void Update()
    {
        // Check if the player has entered the room
        if (playerEnteredRoom == true && Time.time >= nextSpawnTime && currentEnemyIndex < enemyPrefab.Count)
        {
            Instantiate(enemyPrefab[currentEnemyIndex], enemySpawnPoint[currentEnemyIndex].position, enemySpawnPoint[currentEnemyIndex].rotation);
            currentEnemyIndex++;
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private bool playerEnteredRoom = false;
On

    {
        get
        {
            if(entranceTrigger.GetComponent<BoxCollider2D>().bounds.Contains(playerCharacter.transform.position))
            {
                return true;
            }
            else
            return false;
        }
    }

    private GameObject playerCharacter;

    private void Start()
    {
        // Find and store a reference to the player character (you may need to adjust this)
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
    }
}
