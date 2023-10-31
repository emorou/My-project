using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData : MonoBehaviour
{
    public int level;
    public int gold;
    public int experience;
    public int experienceCap;
   
    public GameData()
    {
        level = 0;
        gold = 0;
        experience = 0;
        experience = 0;
    }
}
