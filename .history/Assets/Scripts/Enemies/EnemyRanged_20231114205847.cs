using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    Transform player;

    public GameObject bullet;

    private float shootCooldown;

    private float startShotCooldown;

    void Start()
    {
        shootCooldown = startShotCooldown;
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update()
    {
        Vector2 direction = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);    

        transform.up = direction;

        if(shootCooldown <= 0)
        {
            Instantiate(bullet, transform.position,)
        }
    }
}
