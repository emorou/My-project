using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public CharacterScriptableObject characterData;
    float currentHealth;
    float currentMoveSpeed;

    [Header("I-Frames")]
    public float invincibilityDuration;
    public float invincibilityTimer;
    public bool isInvincible;

    public int gold;

    public TMP_Text goldText;
    public TMP_Text levelText;
    public TMP_Text healthText;
    public TMP_Text bulletText;

    public static PlayerStats Instance; 

    public void IncreaseGold(int amount)
    {
        gold += amount; 
    }

    void Update()
    {
        if(invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }
        else if(isInvincible)
        {
            isInvincible = false;
        }
    }

    void Awake()
    {
        Instance = this;
        currentHealth = characterData.MaxHealth;
        currentMoveSpeed = characterData.MoveSpeed;
    } 

    public void TakeDamage(float dmg)
    {
        if(!isInvincible)
        {
            currentHealth -= dmg;

            invincibilityTimer = invincibilityDuration;
            isInvincible = true;

            if(currentHealth <= 0)
            {
                Kill();
            }
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    public void RestoreHealth(float amount)
    {
        if(currentHealth < characterData.MaxHealth)
        {
            currentHealth += amount;

            if(currentHealth > characterData.MaxHealth)
            {
                currentHealth = characterData.MaxHealth;
            }
        }
    }
}
