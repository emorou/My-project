using System;
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

    public GameData data;

    void Start()
    {
        data = GameData.Instance;
        experienceCapIndex = level - 1;
        experienceCap = levelRanges[experienceCapIndex].experienceCapIncrease;
    }

    public void LoadData(GameData data)
    {
        gold = GameData.Instance.gold;
        level = GameData.Instance.level;
        experience = GameData.Instance.experience;
        experienceCap = GameData.Instance.experienceCap;
    }

    public void SaveData(GameData data)
    {
        GameData.Instance.gold = gold;
        GameData.Instance.level = level;
        GameData.Instance.experience = experience;
        GameData.Instance.experienceCap = experienceCap;
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
            Kill(); 
        }
    }
}

    public void Kill()
    {
        gold = Math.Ceiling(gold - (gold * 0.05));
        GameData.Instance.gold = Math.Ceiling
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