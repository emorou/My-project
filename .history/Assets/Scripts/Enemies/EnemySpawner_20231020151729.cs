using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefab;
    public List<Transform> enemySpawnPoint;
    public float spawnInterval = 2.0f;
    public float nextSpawnTime = 0.0f;
    public int currentEnemyIndex = 0;

    public GameObject entranceTrigger; // Drag and drop the entrance trigger GameObject here
    private bool roomIsClear= false;

    private void Update()
    {
        // Check if the player has entered the room
        if (!roomIsClear && playerEnteredRoom && Time.time >= nextSpawnTime && currentEnemyIndex < enemyPrefab.Count)
        {
            Instantiate(enemyPrefab[currentEnemyIndex], enemySpawnPoint[currentEnemyIndex].position, enemySpawnPoint[currentEnemyIndex].rotation);
            currentEnemyIndex++;
            nextSpawnTime = Time.time + spawnInterval;
            roomIsClear = true;
        }
    }

    private bool playerEnteredRoom = false;

private void OnTriggerEnter2D(Collider2D other) {
    Debug.Log("TETETETT");
    if(other.gameObject.CompareTag("Arena/Entrance")) playerEnteredRoom = true;
    else playerEnteredRoom = false;
}


    private GameObject playerCharacter;

    private void Start()
    {
        // Find and store a reference to the player character (you may need to adjust this)
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
    }
}
