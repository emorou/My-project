[System.Serializable]

public class GameData
{
    public long lastUpdated;
    public int level;
    public double gold;
    public double experience;
    public double experienceCap;
    
    private static GameData instance;

    public static GameData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameData();
            }
            return instance;
        }
    }

    public GameData()
    {
        level = 1;
        gold = 0;
        experience = 0;
        experienceCap = 100;
    }
}
