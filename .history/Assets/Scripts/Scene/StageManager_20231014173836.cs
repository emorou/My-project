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

    private GameData gameData;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        knifeController = FindObjectOfType<KnifeController>();
    }

    void Update()
    {
        goldText.text = "Gold : " + gameData.gold;
        levelText.text = "Level : " + gameData.level + " (" + gameData.experience + " / " + gameData.experienceCap + " )";
        healthText.text = "HP : " + playerStats.currentHealth;
        bulletText.text = "( " + knifeController.currentClip + " / " + knifeController.currentAmmo + " ) "; 
    }
}
