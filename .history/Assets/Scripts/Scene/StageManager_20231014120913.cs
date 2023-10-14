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

    private PlayerStats playerStats;
    private KnifeController knifeController;
    private PlayerLevel playerLevel;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        knifeController = FindObjectOfType<KnifeController>();
        playerLevel = FindObjectOfType<PlayerLevel>();
    }

    void  Update()
    {
        goldText.text = "Gold : " + playerStats.gold;
        levelText.text = "Level : " + playerStats.level + " (" + level.experience + " / " + level.experienceCap + " )";
        healthText.text = "HP : " + currentHealth;
        bulletText.text = "( " + knifeController.currentClip + " / " + knifeController.currentAmmo + " ) "; 
    }
}
