// EnemySpawner.cs
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

    public void SpawnEnemy()
    {
        if (!roomIsClear && Time.time >= nextSpawnTime && currentEnemyIndex < enemyPrefab.Count)
        {
            GameObject newEnemy = Instantiate(enemyPrefab[currentEnemyIndex], enemySpawnPoint[currentEnemyIndex].position, enemySpawnPoint[currentEnemyIndex].rotation);
            currentEnemyIndex++;
            nextSpawnTime = Time.time + spawnInterval;

            // Attach the EnemyStats component and add it to the list
            EnemyStats enemyStats = newEnemy.GetComponent<EnemyStats>();
            if (enemyStats != null)
            {
                enemyStats.SetEnemySpawner(this);
                enemyPrefab.Add(newEnemy);
            }
        }
    }

    public void RemoveEnemy(GameObject enemyToRemove)
    {
        enemyPrefab.Remove(enemyToRemove);
    }

    private GameObject playerCharacter;

    private void Start()
    {
        // Find and store a reference to the player character (you may need to adjust this)
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
    }
}