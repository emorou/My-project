using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    private PlayerStats player;

    public int experience = 0;
    public int level = 1;
    public int experienceCap;

    [System.Serializable]
    public class LevelRange
    {
        public int startLevel;
        public int endLevel;
        public int experienceCapIncrease;
    }

    public List<LevelRange> levelRanges;

    // Track the remaining gold for the current level
    private int remainingGoldForCurrentLevel = 0;

    void Start()
    {
        player = FindObjectOfType<PlayerStats>();
        experienceCap = levelRanges[0].experienceCapIncrease;
    }

    public void IncreaseLevel()
    {
        int goldToConvert = player.gold;

        if (goldToConvert > 0)
        {
            // Calculate the maximum gold that can be converted for the current level
            int maxGoldToConvert = experienceCap - experience;

            // If goldToConvert exceeds the maximum, use the maximum
            if (goldToConvert > maxGoldToConvert)
            {
                goldToConvert = maxGoldToConvert;
            }

            // Increase experience by the converted gold
            experience += goldToConvert;

            // Subtract the converted gold from the player's gold
            player.gold -= goldToConvert;

            // Update the remaining gold for the current level
            remainingGoldForCurrentLevel = player.gold;
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