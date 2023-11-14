using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    Transform player;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update()
    {
        Vector2 direction = .MoveTowards(transform.position, player.transform.position, enemyData.MoveSpeed * Time.deltaTime);    
    }
}
