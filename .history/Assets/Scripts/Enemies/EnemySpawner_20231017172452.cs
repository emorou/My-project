using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]

    public class Wave
    {
        public string waveName;
        public List<GameObject> enemyPrefabs;
        public List<string> enemyName;
        public List<int> enemyCount;
        public int waveQuota;
        public float spawnInterval;
        public int spawnCount;
    }

    public class EnemyGroup
    {
        public string enemyName;
        public int enemyCount;
        public int spawnCount;
        public GameObject enemyPrefab;
    }
    public List<Wave> waves;
}
