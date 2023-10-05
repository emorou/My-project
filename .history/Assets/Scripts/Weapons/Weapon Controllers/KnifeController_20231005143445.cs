using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : WeaponController
{
    public int currentClip, maxClipSize = 10, currentAmmo, maxAmmoSize = 100; 
    
    protected override void Start()
    {
        currentClip = maxClipSize;
        base.Start();
    }

    protected void KnifeAttack()
    {
        if(currentClip == 0)
        {
            Reload();
        }

        if(currentClip != 0)
        {
        base.Attack();
        currentClip--;
        GameObject spawnedKnife = Instantiate(weaponData.Prefab);
        spawnedKnife.transform.position = transform.position; //Assign the position to be the same as this object which is parented to the player
        spawnedKnife.GetComponent<KnifeBehaviour>().DirectionChecker(pm.lastMovedVector);   //Reference and set the direction  
        }
    }

    public void Reload()
    {
        int reloadAmount = maxClipSize - currentClip;
        reloadAmount = (currentAmmo - reloadAmount) >= 0 ? reloadAmount : currentAmmo;
        currentClip += reloadAmount;
        currentAmmo -= reloadAmount;
    }

    public void RestoreAmmo(int amount)
    {
        if(currentAmmo < maxAmmoSize)
        {
            currentAmmo += amount;
        }
    }
}


