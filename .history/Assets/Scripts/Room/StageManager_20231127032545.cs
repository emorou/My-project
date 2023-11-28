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
    
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        knifeController = FindObjectOfType<KnifeController>();
    }

    void Update()
    {
        goldText.text = "Gold : " + playerStats.gold;
        levelText.text = "Level : " + playerStats.level + " (" + playerStats.experience + " / " + playerStats.experienceCap + " )";
        healthText.text = "HP : " + playerStats.currentHealth + " / " + playerStats.characterData.MaxHealth;
        bulletText.text = knifeController.currentClip + " / " + knifeController.currentAmmo;

        if(player == null)
        {
            deathScreen.SetActive(true);
        }

    }
    
    public void WinButton()
    {
        DataPersistenceManager.instance.SaveGame();

        SceneManager.LoadSceneAsync("Lobby");
    }
    
    public void Level1Button()
    {
        // saveButton.onClick.RemoveAllListeners();
        saveButton.onClick.AddListener(() =>
        {
            DataPersistenceManager.instance.SaveGame();
        });
        saveButton.onClick.AddListener(() =>
        {
            SceneManager.LoadSceneAsync("Level 1");
        });
        
    }

    public void DeathGameButton()
    {
        SceneManager.LoadSceneAsync("Lobby");
    }
}
