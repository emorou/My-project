using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NewQuest 
{
    public bool isActive;

    public string title;
    public string description;
    public int experienceReward;
    public int goldReward;

    public NewQuestGoal goal;

    public void Complete()
    {
        isActive = false;
        Debug.Log(title + " was completed");
    }
}
