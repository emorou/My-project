using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public TMP_Text goldText;
    public TMP_Text levelText;
    public TMP_Text healthText;
    public TMP_Text bulletText;

    private PlayerStats playerStats;
    private KnifeController knifeController;

    public GameObject player;
    public GameObject deathScreen;

    public Button saveButton;
    public Button deathButton;

    private DataPersistenceManager dataPersistenceManager;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        knifeController = FindObjectOfType<KnifeController>();
    }

    void Update()
    {
        goldText.text = "Gold : " + playerStats.gold;
        levelText.text = "Level : " + playerStats.level + " (" + playerStats.experience + " / " + playerStats.experienceCap + " )";
        healthText.text = "HP : " + playerStats.currentHealth;
        bulletText.text = "( " + knifeController.currentClip + " / " + knifeController.currentAmmo + " ) ";

        if(player == null)
        {
            deathScreen.SetActive(true);
        }

    }

    public void WinGameButton()
    {
        // saveButton.onClick.RemoveAllListeners();
        saveButton.onClick.AddListener(() =>
        {
            DataPersistenceManager.instance.SaveGame();
        });
        saveButton.onClick.AddListener(() =>
        {
            SceneManager.LoadSceneAsync("Lobby");
        });
        
    }

    public void DeathGameButton()
    {
        // saveButton.onClick.RemoveAllListeners();
        deathButton.onClick.AddListener(() =>
        {
            DataPersistenceManager.instance.LoadGame();
        });
        deathButton.onClick.AddListener(() =>
        {
            SceneManager.LoadSceneAsync("Lobby");
        });
    }
}
