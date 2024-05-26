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
        
        if (!DialogueManager.instance.dialogueIsPlaying && currentCooldownRanged <= 0f && Input.GetMouseButton(1) && !Pause.instance.GameIsPaused && !ShopManager.Instance.isShopAppear && knifeController.currentClip != 0 )   //Once the cooldown becomes 0, attack
        {
            KnifeAttack();
        }

        if (!DialogueManager.instance.dialogueIsPlaying && knifeController.currentClip == 0 || Input.GetKeyDown(KeyCode.R) && !Pause.instance.GameIsPaused && !ShopManager.Instance.isShopAppear)
        {
            knifeController.Reload();
        }
    }

    protected virtual void KnifeAttack()
    {
        AudioManager.instance.PlaySFX("Suara Pistol");
        currentCooldownRanged = weaponData.CooldownDurationRanged;
    }


}
