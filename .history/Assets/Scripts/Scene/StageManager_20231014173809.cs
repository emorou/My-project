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

    private KnifeController knifeController;

    private GameData gameData;

    void Start()
    {
        gameData = FindObjectOfType<GameData>();
        knifeController = FindObjectOfType<KnifeController>();
    }

    void Update()
    {
        goldText.text = "Gold : " + gameData.gold;
        levelText.text = "Level : " + gameData.level + " (" + gameData.experience + " / " + gameData.experienceCap + " )";
        healthText.text = "HP : " + playerStat.currentHealth;
        bulletText.text = "( " + knifeController.currentClip + " / " + knifeController.currentAmmo + " ) "; 
    }
}
