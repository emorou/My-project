using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Sysm]
    public class Wave
    {
        public string waveName;
        public int waveQuota;
        public float spawnInterval;
        public int spawnCount;
    }
}
