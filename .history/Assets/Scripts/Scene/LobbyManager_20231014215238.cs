using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LobbyManager : MonoBehaviour
{
    public TMP_Text goldText;
    public TMP_Text levelText;

    private PlayerStats playerStats;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    void Update()
    {
        goldText.text = "Gold : " + playerStats.gold;
        levelText.text = "Level : " + playerStats.level + " (" + playerStats.experience + " / " + playerStats.experienceCap + " )";
}
