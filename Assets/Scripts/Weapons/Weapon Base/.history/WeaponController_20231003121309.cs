using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base script for all weapon controllers
/// </summary>
public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public WeaponScriptableObject weaponData;   

    float currentCooldown;

    protected PlayerMovement pm;

    public KnifeController knifecontroller;

    protected virtual void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
        currentCooldown = weaponData.CooldownDuration; //At the start set the current cooldown to be cooldown duration
    }

    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f && Input.GetKeyDown(KeyCode.Space))   //Once the cooldown becomes 0, attack
        {
            Attack();
        }

        if(knifecontroller.currentClip == 0)
        {
            knifecontroller.Reload();
        }
    }

    protected virtual void Attack()
    {
        currentCooldown = weaponData.CooldownDuration;
    }


}
