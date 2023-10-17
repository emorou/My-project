using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefab;
    public List<Transform> enemySpawnPoint;

    void Update()
    {
        for (int i = 0; i < enemyPrefab.Count; i++)
        {
            Instantiate(enemyPrefab[i], enemySpawnPoint[i]);
        }
    } 
}
