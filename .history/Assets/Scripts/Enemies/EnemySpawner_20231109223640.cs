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

    public GameObject entranceTrigger; // Drag and drop the entrance trigger GameObject here

    private void Update()
    {
        // Check if the player has entered the room
        if (HasPlayerEnteredRoom() && Time.time >= nextSpawnTime && currentEnemyIndex < enemyPrefab.Count)
        {
            Instantiate(enemyPrefab[currentEnemyIndex], enemySpawnPoint[currentEnemyIndex].position, enemySpawnPoint[currentEnemyIndex].rotation);
            currentEnemyIndex++;
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    public bool HasPlayerEnteredRoom()
    {
        if (entranceTrigger == null)
            return false;

        // Check if the player has entered the trigger volume
        return entranceTrigger.GetComponent<BoxCollider2D>().bounds.Contains(playerCharacter.transform.position);
    }

    public GameObject playerCharacter;

    private void Start()
    {
        // Find and store a reference to the player character (you may need to adjust this)
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
    }
}