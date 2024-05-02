using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IDataPersistence
{
    public CharacterScriptableObject characterData;
    public float currentHealth;
    public float maxHealth;
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
    void Start()
    {
        LevelUpStats();
        experienceCapIndex = level - 1;
        experienceCap = levelRanges[experienceCapIndex].experienceCapIncrease;
        if(DataToKeep.isPlayerDead)
        {
            Debug.Log("player is dead");
            gold = Math.Ceiling(gold - (gold * 0.05));
            DataToKeep.isPlayerDead = false;
        }
        else if(!DataToKeep.isPlayerDead)
        {
            Debug.Log("player is not dead");
        }
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

    public void IncreaseGold(int amount)
    {
        gold += amount;
    }

    void Update()
    {
        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }
        else if (isInvincible)
        {
            isInvincible = false;
        }
    }

    void Awake()
    {
        Instance = this;
        currentMoveSpeed = characterData.MoveSpeed;
    }

    public void LevelUpStats()
    {
        maxHealth = characterData.MaxHealth;
        if(level == 1)
        {
            currentHealth = maxHealth;
        }
        else
        maxHealth = 50 + (level * 50);
        currentHealth = maxHealth;
    }
    public void TakeDamage(float dmg)
    {
        if (!isInvincible)
        {
            currentHealth -= dmg;

            invincibilityTimer = invincibilityDuration;
            isInvincible = true;
        }
    }
    
    public void RestoreHealth(float amount)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += amount;

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
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
            LevelUpStats();

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
