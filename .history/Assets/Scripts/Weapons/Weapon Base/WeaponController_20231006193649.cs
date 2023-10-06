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

    private KnifeController knifeController;

    protected virtual void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
        knifeController = FindObjectOfType<KnifeController>();
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
        if(knifeController.currentClip == 0 || Input.GetKeyDown(KeyCode.R))
            {
                knifeController.Reload();
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
