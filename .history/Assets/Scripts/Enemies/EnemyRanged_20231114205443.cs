using System.Threading.Tasks.Dataflow;
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
        Vector2 direction = new Vector2(player.position.x - transform.position.x, player.transform.position, enemyData.MoveSpeed * Time.deltaTime);    
    }
}
