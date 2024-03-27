using System.Collections.Generic;
[System.Serializable]

public class GameData
{
    public long lastUpdated;
    public int level;
    public double gold;
    public double experience;
    public double experienceCap;

     public List<Item> InventoryItems;
    public GameData()
    {
        level = 1;
        gold = 0;
        experience = 0;
        experienceCap = 100;
        InventoryItems = new List<Item>();
    }
}
