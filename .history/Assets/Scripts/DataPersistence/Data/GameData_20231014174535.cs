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
        level = 0;
        gold = 0;
        experience = 0;
        experienceCap = 0;

        playerStats.level = 0;
        playerStats.gold = 0;
        playerStats.experience = 0;


    }
}
