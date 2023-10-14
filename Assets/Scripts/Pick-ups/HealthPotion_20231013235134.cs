using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour, ICollectible
{
    public int healthToRestore;
     public void Collect()
    {
        PlayerStats player = FindObjectOfType<KnifeController>();
        ammo.RestoreHealth(healthToRestore);
        Destroy(gameObject);
    }
}
