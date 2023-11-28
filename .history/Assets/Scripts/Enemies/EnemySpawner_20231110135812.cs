using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Prefab> enemyPrefab;
    public List<Transform> enemySpawnPoint;
    public int currentEnemyIndex = 0;

    public GameObject entranceTrigger; // Drag and drop the entrance trigger GameObject here
    [SerializeField] private bool roomIsClear= false;

 public void SpawnEnemy()
 {
    if (!roomIsClear && currentEnemyIndex < enemyPrefab.Count)
        {
            for(int i  = 0; i < enemyPrefab.Count; i++)
            {
            Instantiate(enemyPrefab[currentEnemyIndex], enemySpawnPoint[currentEnemyIndex].position, enemySpawnPoint[currentEnemyIndex].rotation);
            currentEnemyIndex++;
            }
            roomIsClear = true;
        }
 }

    public void RemoveEnemyFromList()
    {
        enemyPrefab.Destroy(enemyPrefab);
        enemyPrefab.Remove(gameObject);
    }
    
    private GameObject playerCharacter;

    private void Start()
    {
        // Find and store a reference to the player character (you may need to adjust this)
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
    }
}
