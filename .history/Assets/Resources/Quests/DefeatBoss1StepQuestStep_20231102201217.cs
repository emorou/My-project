using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatBoss1Step : QuestStep, MonoBehaviour
{
    private bool isBossDefeated = false;

    private void Update()
    {
        if(gameObject == null)
        {
            isBossDefeated = true;
            
        }
    }
}
