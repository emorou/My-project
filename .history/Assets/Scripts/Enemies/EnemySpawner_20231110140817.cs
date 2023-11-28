using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefab;
    public List<Transform> enemySpawnPoint;
    public int currentEnemyIndex = 0;

    public GameObject entranceTrigger; // Drag and drop the entrance trigger GameObject here
    [SerializeField] private bool roomIsClear= false;

    public void SpawnEnemy()
    {
        do 
        {
            Instantiate(enemyPrefab[currentEnemyIndex], enemySpawnPoint[currentEnemyIndex].position, enemySpawnPoint[currentEnemyIndex].rotation);
            currentEnemyIndex++;
            enemyPrefab.Remove(enemyPrefab[currentEnemyIndex - 1]);
        }

        while(!roomIsClear);

        if (enemyPrefab.Count == 0)
        {
            roomIsClear = true;
        }
 }

    public void RemoveEnemyFromList()
    {
        enemyPrefab.Remove(gameObject);
    }
    
    private GameObject playerCharacter;

    private void Start()
    {
        // Find and store a reference to the player character (you may need to adjust this)
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
    }
}
