using UnityEngine;

[System.Serializable]

public class GameData : MonoBehaviour 

{
    public long lastUpdated;
    public int level;
    public double gold;
    public double experience;
    public double experienceCap;

    public GameData()
    {
        level = 1;
        gold = 0;
        experience = 0;
        experienceCap = 100;
    }
}
