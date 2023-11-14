using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefab;
    public List<Transform> enemySpawnPoint;
    public float spawnInterval = 2.0f;
    public float nextSpawnTime = 0.0f;
    public int currentEnemyIndex = 0;

    public GameObject entranceTrigger; // Drag and drop the entrance trigger GameObject here
    [SerializeField] private bool roomIsClear = false;

    private List<GameObject> spawnedEnemies = new List<GameObject>(); // Keep track of spawned enemies

    public void SpawnEnemy()
    {
        if (!roomIsClear && Time.time >= nextSpawnTime && currentEnemyIndex < enemyPrefab.Count)
        {
            GameObject enemyInstance = Instantiate(enemyPrefab[currentEnemyIndex], enemySpawnPoint[currentEnemyIndex].position, enemySpawnPoint[currentEnemyIndex].rotation);
            spawnedEnemies.Add(enemyInstance); // Add the spawned enemy to the list
            currentEnemyIndex++;
            nextSpawnTime = Time.time + spawnInterval;
            roomIsClear = true;
        }
    }

    // Call this method to remove an enemy from the list
    public void RemoveEnemy(GameObject enemy)
    {
        spawnedEnemies.Remove(enemy);
    }

    private GameObject playerCharacter;

    private void Start()
    {
        // Find and store a reference to the player character (you may need to adjust this)
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
    }
}