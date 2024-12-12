using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NewQuestGoal 
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;

    public bool isReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void EnemyKilled()
    {
        if(goalType == GoalType.Kill)
        currentAmount++;
    }

    public void ItemCollected()
    {
        if(goalType == GoalType.Gathering)
        currentAmount++;
    }
}

public enum GoalType
{
    Kill,
    Gathering
}
