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
    
    public GameData()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }
}
