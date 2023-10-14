using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour, ICollectible
{
    int health
     public void Collect()
    {
        KnifeController ammo = FindObjectOfType<KnifeController>();
        ammo.RestoreAmmo(ammoToRestore);
        Destroy(gameObject);
    }
}
