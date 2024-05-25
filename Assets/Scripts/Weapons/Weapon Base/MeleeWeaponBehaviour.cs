using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base script of all melee behaviours [To be placed on a prefab of a weapon that is melee]
/// </summary>
public class MeleeWeaponBehaviour : WeaponController
{
    // public WeaponScriptableObject weaponData;

    //Current stats
    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    
    float currentCooldownMelee;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject sword;

    public float test;

    protected virtual void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDurationMelee;
    }

    protected void Update()
    {
        currentCooldownMelee -= Time.deltaTime;
        if (!DialogueManager.instance.dialogueIsPlaying && currentCooldownMelee <= 0f && Input.GetMouseButton(0) && !Pause.instance.GameIsPaused && !ShopManager.Instance.isShopAppear)   //Once the cooldown becomes 0, attack
        {
            MidSwordAttack(); 
        }
    }
     protected virtual void MidSwordAttack()
    {
        currentCooldownMelee = weaponData.CooldownDurationMelee;

        // Get the player position
        Vector3 playerPos = transform.position;

        // Get the mouse position in world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // Calculate the direction vector from the player to the mouse
        Vector3 direction = mousePos - playerPos;

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Ensure the angle is within the range 0 to 360 degrees
        if (angle < 0)
        {
            angle += 360;
        }

        test = angle;

        // Trigger the attack animation
        if (angle > 0 && angle < 60 ) // Adjust this condition as needed
        {
            AudioManager.instance.PlaySFX("Suara Pedang");
            anim.SetTrigger("Back Attack");
        }
        else if(angle > 300 && angle < 360)
        {
            AudioManager.instance.PlaySFX("Suara Pedang");
            anim.SetTrigger("Back Attack");
        }
        else if(angle > 60 && angle < 120)
        {
            AudioManager.instance.PlaySFX("Suara Pedang");
            anim.SetTrigger("Top Attack");
        }
        else if(angle > 120 && angle < 240)
        {
            AudioManager.instance.PlaySFX("Suara Pedang");
            anim.SetTrigger("Left Attack");
        }
        else if(angle > 240 && angle < 300)
        {
            AudioManager.instance.PlaySFX("Suara Pedang");
            anim.SetTrigger("Bottom Attack");
        }
    }

}
