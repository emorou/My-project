using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefab;
    public List<Transform> enemySpawnPoint;
    public float spawnInterval;
    public float nextSpawnTime;
    public int currentEnemyIndex;

    public GameObject entranceTrigger; // Drag and drop the entrance trigger GameObject here
    [SerializeField] private bool roomIsClear = false;

    public List<GameObject> spawnedEnemies = new List<GameObject>(); // Keep track of spawned enemies

    public void SpawnEnemy()
    {
        if (!roomIsClear && Time.time >= nextSpawnTime && currentEnemyIndex < enemyPrefab.Count)
        {
            for(int i  = 0; i < enemyPrefab.Count; i++)
            {
                GameObject enemyInstance = Instantiate(enemyPrefab[currentEnemyIndex], enemySpawnPoint[currentEnemyIndex].position, enemySpawnPoint[currentEnemyIndex].rotation);
                spawnedEnemies.Add(enemyInstance); // Add the spawned enemy to the list
                currentEnemyIndex++;
                nextSpawnTime = Time.time + spawnInterval;
            }
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

    public bool AreAllEnemiesNull()
    {
        return spawnedEnemies.All(enemy => enemy == null);
    }

    public void Update()
    {
        if (enemySpawner.AreAllEnemiesNull())
            {
    // All enemies have been destroyed
    // Do something, such as spawning a new wave of enemies or completing an objective
        }
    }
}
