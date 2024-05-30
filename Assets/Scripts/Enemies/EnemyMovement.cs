using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyScriptableObjects enemyData;
    Transform player;

    Vector2 knockbackVelocity; 
    float knockbackDuration;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update()
    {
        if (knockbackDuration > 0)
        {
            transform.position += (Vector3)knockbackVelocity * Time.deltaTime;
            knockbackDuration -= Time.deltaTime;
        }
        else
        {
            this.spriteRenderer.flipX = player.transform.position.x > this.transform.position.x;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyData.MoveSpeed * Time.deltaTime);    //Constantly move the enemy towards the player
        }
        
    }

    public void Knockback(Vector2 velocity, float duration)
    {
        if (knockbackDuration > 0) return;

        knockbackVelocity = velocity;
        knockbackDuration = duration;
    }
}