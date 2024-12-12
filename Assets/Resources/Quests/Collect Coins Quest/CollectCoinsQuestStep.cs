using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoinsQuestStep : QuestStep
{
    private int coinsCollected = 0;
    private int coinsToComplete = 200;

    private void CoinCollected()
    {
        if(PlayerStats.Instance.gold >= 200)
        {
            FinishQuestStep();
        }
    }
}
