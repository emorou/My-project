using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicController : WeaponController
{
    private Camera cam;
    protected override void Start()
    {
        base.Start();
    }

    protected override void MidSwordAttack()
    {
        base.MidSwordAttack();
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 direction = worldMousePosition - transform.position;
        GameObject spawnedWeapon = Instantiate(weaponData.Prefab);
        spawnedWeapon.transform.position = transform.position; //Assign the position to be the same as this object which is parented to the player
        spawnedWeapon.transform.parent = transform;
    }

}
