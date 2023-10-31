using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour, IDataPersistence
{
    public CharacterScriptableObject characterData;
    public float currentHealth;
    public float currentMoveSpeed;

    [Header("I-Frames")]
    public float invincibilityDuration;
    public float invincibilityTimer;
    public bool isInvincible;

    public int gold;

    public static PlayerStats Instance; 

    private PlayerLevel playerLevel;

    public int experience;
    public int level;
    public int experienceCap;

    public int gold_data;
    public int experience_data;
    public int level_data;
    public int experienceCap_data;

    void Start()
    {
        playerLevel = FindObjectOfType<PlayerLevel>();
        experience = playerLevel.experience;
        level = playerLevel.level;
        experienceCap = playerLevel.experienceCap;
    }

    public void LoadData(GameData data)
    {
        gold_data = data.gold;
        level_data = data.level;
        experience_data = data.experience;
        experienceCap = data.experienceCap;
    }

    public void SaveData(GameData data)
    {
        data.gold = gold;
        data.level = level; 
        data.experience = experience;
        data.experienceCap = experienceCap;
    }

    public void IncreaseGold(int amount)
    {
        gold += amount; 

        gold_data = gold;
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
        experience = playerLevel.experience;
        level = playerLevel.level;
        experienceCap = playerLevel.experienceCap;

        experience_data = experience;
        level_data = level;
        experienceCap_data = experienceCap;
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
        gold /= 5;
        Destroy(gameObject);
        SceneManager.LoadScene("Lobby");
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
