using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageManager : MonoBehaviour
{
    public TMP_Text goldText;
    public TMP_Text levelText;
    public TMP_Text healthText;
    public TMP_Text bulletText;

    void Start()
    {
        PlayerStats playerStats = FindObjectOfType<PlayerStats>();
        KnifeController knifeController = FindObjectOfType<KnifeController>();
    }

    void  Update()
    {
        goldText.text = "Gold : " + PlayerAnimator.gold;
        levelText.text = "Level : " + level.level + " (" + level.experience + " / " + level.experienceCap + " )";
        healthText.text = "HP : " + currentHealth;
        bulletText.text = "( " + knifeController.currentClip + " / " + knifeController.currentAmmo + " ) "; 
    }
}
