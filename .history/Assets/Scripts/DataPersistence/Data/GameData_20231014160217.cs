using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData : MonoBehaviour
{
    private PlayerStats playerStats;
    public int level;
    public int gold;
    public int experience;
    public int experienceCap;

    void Update()
    {
        playerStats = FindObjectOfType
    }
    public GameData()
    {
        level = playerStats.level;
        gold = playerStats.gold;
        experience = playerStats.experience;
        experienceCap = playerStats.experienceCap;
    }
}