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

    float currentCooldownRanged;
    float currentCooldownMelee;

    protected PlayerMovement pm;

    protected virtual void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
        currentCooldownRanged = weaponData.CooldownDurationranged; //At the start set the current cooldown to be cooldown duration
    }

    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f && Input.GetMouseButton(1))   //Once the cooldown becomes 0, attack
        {
            KnifeAttack();
        }

        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f && Input.GetMouseButton(0))   //Once the cooldown becomes 0, attack
        {
            MidSwordAttack();
        }
    }

    protected virtual void MidSwordAttack()
    {
        currentCooldown = weaponData.CooldownDuration;
    }

    protected virtual void KnifeAttack()
    {
        currentCooldown = weaponData.CooldownDuration;
    }


}
