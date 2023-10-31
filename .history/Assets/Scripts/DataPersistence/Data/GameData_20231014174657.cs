[System.Serializable]

public class GameData
{
    public PlayerStats playerStats;
    public int level;
    public int gold;
    public int experience;
    public int experienceCap;
   
    public GameData()
    {
        playerStats = 
        level = playerStats.level;
        gold = playerStats.gold;
        experience = playerStats.experience;
        experienceCap = playerStats.experienceCap;
    }
}
