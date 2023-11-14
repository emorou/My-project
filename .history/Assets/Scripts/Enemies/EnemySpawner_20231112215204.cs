using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static List<GameObject> enemyPrefab = new List<GameObject>();
    public static List<Transform> enemySpawnPoint = new List<Transform>();
    public float spawnInterval = 2.0f;
    public float nextSpawnTime = 0.0f;
    public int currentEnemyIndex = 0;

    public GameObject entranceTrigger; // Drag and drop the entrance trigger GameObject here
    [SerializeField] private bool roomIsClear= false;

    public void SpawnEnemy()
    {
        if (!roomIsClear && Time.time >= nextSpawnTime && currentEnemyIndex < enemyPrefab.Count)
            {
                for(int i  = 0; i < enemyPrefab.Count; i++)
                {
                Instantiate(enemyPrefab[currentEnemyIndex], enemySpawnPoint[currentEnemyIndex].position, enemySpawnPoint[currentEnemyIndex].rotation);
                currentEnemyIndex++;
                nextSpawnTime = Time.time + spawnInterval;
                }
                roomIsClear = true;
            }
    }


    private GameObject playerCharacter;

    private void Start()
    {
        // Find and store a reference to the player character (you may need to adjust this)
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
    }
}