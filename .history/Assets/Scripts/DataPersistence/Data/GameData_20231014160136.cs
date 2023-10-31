using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    private PlayerStats playerStats;
    public int level;
    public int gold;
    public int experience;
    public int experienceCap;
    public GameData()
    {
        level = playerStats.level;
        gold = playerStats.gold;
        gold = 0;
        experience = playerStats.experience;
        experience = 0;
        experienceCap = playerStats.experienceCap;
        experienceCap = 100;
    }
}
