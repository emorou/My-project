using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatBoss1Step : QuestStep, MonoBehaviour
{
    private bool isBossDefeated = false;

    private void BossDefeated()
    {
        if(gameObject == null)
        {
            isBossDefeated = true;
            FinishQuestStep();
        }
    }
}
