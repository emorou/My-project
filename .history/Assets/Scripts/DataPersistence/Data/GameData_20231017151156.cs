[System.Serializable]

public class GameData
{
    public long lastUpdated;
    public int level;
    public double gold;
    public int experience;

    public GameData()
    {
        level = 1;
        gold = 0;
        experience = 0;
    }
}
