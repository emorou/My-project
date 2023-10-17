using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]

    public class Wave
    {
        public string waveName;
        public List<
        public int waveQuota;
        public float spawnInterval;
        public int spawnCount;
    }
}
