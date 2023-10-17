using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefab;
    public List<Transform> enemySpawnPoint;
    public float spawnInterval = 2.0f; // Adjust this to control the spawn rate
    private float nextSpawnTime = 0.0f;
    private int currentEnemyIndex = 0;

    void Update()
    {
        // Check if it's time to spawn the next enemy
        if (Time.time >= nextSpawnTime && currentEnemyIndex < enemyPrefab.Count)
        {
            Instantiate(enemyPrefab[currentEnemyIndex], enemySpawnPoint[currentEnemyIndex].position, enemySpawnPoint[currentEnemyIndex].rotation);
            currentEnemyIndex++;
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
}