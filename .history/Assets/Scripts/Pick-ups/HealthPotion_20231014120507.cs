using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour, ICollectible
{
    public int healthToRestore;

    public void Collect()
    {
        Player ammo = FindObjectOfType<KnifeController>();
        ammo.RestoreAmmo(ammoToRestore);
        Destroy(gameObject);
    }
}