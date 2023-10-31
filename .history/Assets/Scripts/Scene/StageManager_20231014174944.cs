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
    private PlayerLevel Playerlevel;

    public GameData gameData;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        knifeController = FindObjectOfType<KnifeController>();
        Playerlevel = FindObjectOfType<PlayerLevel>();
    }

    void Update()
    {
        goldText.text = "Gold : " + playerStats.gold;
        levelText.text = "Level : " + Playerlevel.level + " (" + Playerlevel.experience + " / " + Playerlevel.experienceCap + " )";
        healthText.text = "HP : " + playerStats.currentHealth;
        bulletText.text = "( " + knifeController.currentClip + " / " + knifeController.currentAmmo + " ) "; 
    }
}
