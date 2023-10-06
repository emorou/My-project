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

    protected override void KnifeAttack()
    {
        if(currentClip == 0)
        {
            Reload();
        }

        if(currentClip != 0)
        {
        base.KnifeAttack();
        currentClip--;
        GameObject spawnedKnife = Instantiate(weaponData.Prefab);
        // spawnedKnife.transform.position = transform.position; //Assign the position to be the same as this object which is parented to the player
        // spawnedKnife.GetComponent<KnifeBehaviour>().DirectionChecker(pm.lastMovedVector);   //Reference and set the direction  
         // Calculate the direction from the player to the mouse cursor
         Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 direction = worldMousePosition - transform.position;

        // Normalize the direction vector to have a magnitude of 1
        direction.Normalize();

        // Offset the spawn position slightly in the direction of the mouse cursor
        Vector3 spawnPosition = transform.position + direction * 0.5f; // Adjust the 0.5f value as needed

        // Instantiate the knife at the spawn position
        GameObject spawnedKnife = Instantiate(weaponData.Prefab, spawnPosition, Quaternion.identity);
        spawnedKnife.GetComponent<KnifeBehaviour>().DirectionChecker(direction);
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


