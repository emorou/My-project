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

    public TMP_Text killCountText;
    private PlayerStats playerStats;
    private KnifeController knifeController;

    public GameObject player;
    public GameObject deathScreen;

    public Slider healthBar;
    public Slider ammoBar;
    public Slider musicSlider;
    public Slider sfxSlider;

    private EnemySpawner enemySpawner;
    private EnemyStats enemyStats;
    void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        knifeController = FindObjectOfType<KnifeController>();
        enemyStats = FindObjectOfType<EnemyStats>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        healthBar.value = playerStats.currentHealth;
        ammoBar.value = knifeController.currentClip;
    }

    void Update()
    {
        healthBar.value = playerStats.currentHealth;
        healthBar.maxValue = playerStats.maxHealth;
        ammoBar.value = knifeController.currentClip;
        goldText.text = "" + playerStats.gold;
        levelText.text = playerStats.level + " (" + playerStats.experience + " / " + playerStats.experienceCap + " )";
        healthText.text = playerStats.currentHealth + " / " + playerStats.maxHealth;
        bulletText.text = knifeController.currentClip + " / " + knifeController.currentAmmo;

        if (playerStats.currentHealth <= 0)
        {
            DataToKeep.isPlayerDead = true;
            // Time.timeScale = 0f;
            deathScreen.SetActive(true);
        }

        if (!enemySpawner.AreAllEnemiesNull())
            killCountText.text = "";
        else
            killCountText.text = " / " + enemySpawner.enemyPrefab.Count;
        // killCountText.text = enemyStats.killCount + " / " + enemySpawner.enemyPrefab.Count;
    }

    public void WinButton()
    {
        DataPersistenceManager.instance.SaveGame();

        LevelLoader.instance.NextLevel(5);
    }

    public void Level1Button()
    {
        DataPersistenceManager.instance.SaveGame();

        LevelLoader.instance.NextLevel(6);

    }

    public void DeathGameButton()
    {
        Time.timeScale = 1f;
        LevelLoader.instance.NextLevel(5);
    }

    public void ToggleMusic()
    {
        AudioManager.instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.instance.ToggleSFX();
    }

    public void MusicVolume()
    {
        AudioManager.instance.MusicVolume(musicSlider.value);
    }

    public void SFXVolume()
    {
        AudioManager.instance.SFXVolume(musicSlider.value);
    }
}