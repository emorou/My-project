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
    public bool ableToTeleport = true;
    public bool playerEnteredRoom = false;
    public bool isRoomClear = false;
    public List<GameObject> spawnedEnemies = new List<GameObject>(); // Keep track of spawned enemies

    private EnemyStats enemyStats;
    public void SpawnEnemy()
    {
        ableToTeleport = false;
        playerEnteredRoom = true;
        if (playerEnteredRoom && Time.time >= nextSpawnTime && currentEnemyIndex < enemyPrefab.Count)
        {
            for (int i = 0; i < enemyPrefab.Count; i++)
            {
                GameObject enemyInstance = Instantiate(enemyPrefab[currentEnemyIndex], enemySpawnPoint[currentEnemyIndex].position, enemySpawnPoint[currentEnemyIndex].rotation);
                spawnedEnemies.Add(enemyInstance);
                currentEnemyIndex++;
                nextSpawnTime = Time.time + spawnInterval;
            }
        }
    }

    public void RemoveEnemy(GameObject enemy)
    {
        spawnedEnemies.Remove(enemy);
    }

    private GameObject playerCharacter;

    private void Start()
    {
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
    }

    public bool AreAllEnemiesNull()
    {
        return spawnedEnemies.All(enemy => enemy == null);
    }

    public void Update()
    {
        if (AreAllEnemiesNull() && playerEnteredRoom)
        {
            enemyStats.killCount = 0;
            ableToTeleport = true;
            isRoomClear = true;
        }
    }
}