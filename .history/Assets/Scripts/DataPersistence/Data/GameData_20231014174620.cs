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
        level = playerStats.level;
        gold = playerStats.gold;
        experience = playerStats.experienc;
        experienceCap = playerStats.experienceCap;

        playerStats.level = 0;
        playerStats.gold = 0;
        playerStats.experience = 0;
        playerStats.experience = 0;
    }
}
