using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefab;
    public List<Transform> enemySpawnPoint;
    public float spawnInterval = 2.0f;
    private float nextSpawnTime = 0.0f;
    private int currentEnemyIndex = 0;

    private bool playerEnteredRoom = false; // Tracks if the player entered the room

     public GameObject entranceTrigger;
    // OnTriggerEnter is called when a collider enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the player has a "Player" tag
        {
            playerEnteredRoom = true;
        }
    }

    void Update()
    {
        // Check if the player has entered the room and it's time to spawn the next enemy
        if (playerEnteredRoom && Time.time >= nextSpawnTime && currentEnemyIndex < enemyPrefab.Count)
        {
            Instantiate(enemyPrefab[currentEnemyIndex], enemySpawnPoint[currentEnemyIndex].position, enemySpawnPoint[currentEnemyIndex].rotation);
            currentEnemyIndex++;
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
}
