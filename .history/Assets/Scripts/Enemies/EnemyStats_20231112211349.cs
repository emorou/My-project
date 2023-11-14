using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObjects enemyData;
    private EnemySpawner enemySpawner;

    float currentMoveSpeed;
    float currentHealth;
    float currentDamage;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
        for (int n = enemySpawner.enemyPrefab.Count - 1; n >= 0; n--) 
        {
            if(enemySpawner.enemyPrefab[n] == null)
            {
                enemySpawner.enemyPrefab.RemoveAt(n);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerStats player = col.gameObject.GetComponent<PlayerStats>();
            player.TakeDamage(currentDamage);
        }

        
    }
}
