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
        currentCooldownRanged = weaponData.CooldownDurationRanged; //At the start set the current cooldown to be cooldown duration
        currentCooldownMelee = weaponData.CooldownDurationMelee;
    }

    protected virtual void Update()
    {
        currentCooldownRanged -= Time.deltaTime;
        currentCooldownMelee -= Time.deltaTime;
        if (currentCooldownRanged <= 0f && Input.GetMouseButton(1))   //Once the cooldown becomes 0, attack
        {
            KnifeAttack();
        }
        else if(currentCooldownMelee <= 0f && Input.GetMouseButton(0))   //Once the cooldown becomes 0, attack
        {
            MidSwordAttack();
        }
    }

    protected virtual void MidSwordAttack()
    {
        currentCooldownMelee = weaponData.CooldownDurationMelee;
    }

    protected virtual void KnifeAttack()
    {
        currentCooldownRanged = weaponData.CooldownDurationRanged;
    }


}
