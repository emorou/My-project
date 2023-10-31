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

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }
   
    public GameData()
    {
        level = playerStats.level;
        level = 0;
        gold = playerStats.gold;
        gold = 0;
        experience = playerStats.experience;
        experience = 0;
        experienceCap = playerStats.experienceCap;
        experience = 0;
    }
}
