using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceGem : MonoBehaviour, ICollectible
{
    public int goldGranted;
    private PlayerStats player;

    public void Collect()
    {
        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.IncreaseGold(goldGranted);
        Destroy(gameObject); 
    }
}
