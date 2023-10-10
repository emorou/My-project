using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour, ICollectible
{
    public int ammoToRestore;

    public void Collect()
    {
        KnifeController ammo = FindObjectOfType<KnifeController>();
        ammo.RestoreAmmo(ammo);
        Destroy(gameObject);
    }
}
