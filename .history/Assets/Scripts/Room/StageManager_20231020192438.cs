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

    private DataPersistenceManager dataPersistenceManager;

    private GameData data;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        knifeController = FindObjectOfType<KnifeController>();
    }

    void Update()
    {
        goldText.text = "Gold : " + data.gold;
        levelText.text = "Level : " + data.level + " (" + playerStats.experience + " / " + playerStats.experienceCap + " )";
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

    public void BackToLobbyButton()
    {
        SceneManager.LoadSceneAsync("Lobby");
    }

    public void LoadGameButton()
    {
        saveButton.onClick.AddListener(() =>
        {
            DataPersistenceManager.instance.LoadGame();
        });
        saveButton.onClick.AddListener(() =>
        {
            SceneManager.LoadSceneAsync("Lobby");
        });
    }
}
