using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class PlayerStats : MonoBehaviour, IDataPersistence
{
    public CharacterScriptableObject characterData;
    public float currentHealth;
    public float currentMoveSpeed;

    [Header("I-Frames")]
    public float invincibilityDuration;
    public float invincibilityTimer;
    public bool isInvincible;

    public double gold;

    public static PlayerStats Instance;

    public double experience = 0;
    public int level = 1;
    public double experienceCap;
    public int experienceCapIndex;
    
    [System.Serializable]
    public class LevelRange
    {
        public int startLevel;
        public int endLevel;
        public int experienceCapIncrease;
    }

    public List<LevelRange> levelRanges;
    private double remainingGoldForCurrentLevel = 0;
    public bool isPlayerDead;

    void Start()
    {
        experienceCapIndex = level - 1;
        experienceCap = levelRanges[experienceCapIndex].experienceCapIncrease;
    }

    public void LoadData(GameData data)
    {
        gold = data.gold;
        level = data.level;
        experience = data.experience;
        experienceCap = data.experienceCap;
    }

    public void SaveData(GameData data)
    {
        data.gold = gold;
        data.level = level;
        data.experience = experience;
        data.experienceCap = experienceCap;
    }

    public void SaveDeathData(GameData data)
    {
        gold = data.gold;
        data.gold = Math.Ceiling(data.gold - (data.gold * 0.05));
    }

    public void IncreaseGold(int amount)
    {
        gold += amount;
    }

    void Update()
    {
        isPlayerDead = false;

        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }
        else if (isInvincible)
        {
            isInvincible = false;
        }

        if(isPlayerDead)
        {
            gold = Math.Ceiling(gold - (gold * 0.05));
            isPlayerDead = false;
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
    if (!isInvincible)
    {
        currentHealth -= dmg;

        invincibilityTimer = invincibilityDuration;
        isInvincible = true;

        if (currentHealth <= 0)
        {
            Kill(); // Pass the GameData object to the Kill method
        }
    }
}

    public void Kill()
    {
        isPlayerDead = true;
        Destroy(gameObject);
    }
    
    public void RestoreHealth(float amount)
    {
        if (currentHealth < characterData.MaxHealth)
        {
            currentHealth += amount;

            if (currentHealth > characterData.MaxHealth)
            {
                currentHealth = characterData.MaxHealth;
            }
        }
    }

    public void IncreaseLevel()
    {
        double goldToConvert = gold;

        if (goldToConvert > 0)
        {
            // Calculate the maximum gold that can be converted for the current level
            double maxGoldToConvert = experienceCap - experience;

            // If goldToConvert exceeds the maximum, use the maximum
            if (goldToConvert > maxGoldToConvert)
            {
                goldToConvert = maxGoldToConvert;
            }

            // Increase experience by the converted gold
            experience += goldToConvert;

            // Subtract the converted gold from the player's gold
            gold -= goldToConvert;

            // Update the remaining gold for the current level
            remainingGoldForCurrentLevel = gold;
        }

        LevelUpChecker();
    }

    public void LevelUpChecker()
    {
        if (experience >= experienceCap)
        {
            level++;
            experience -= experienceCap;

            int experienceCapIncrease = 0;
            foreach (LevelRange range in levelRanges)
            {
                if (level >= range.startLevel && level <= range.endLevel)
                {
                    experienceCapIncrease = range.experienceCapIncrease;
                    break; // Exit the loop once the appropriate range is found
                }
            }
            experienceCap += experienceCapIncrease;
        }
    }
}
