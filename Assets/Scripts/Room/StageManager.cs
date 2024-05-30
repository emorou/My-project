using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public TMP_Text goldText;
    public TMP_Text levelText;
    public TMP_Text healthText;
    public TMP_Text bulletText;
    public TMP_Text enemyCountText;

    private PlayerStats playerStats;
    private KnifeController knifeController;
    private EnemySpawner enemySpawner;

    public GameObject player;
    public GameObject deathScreen;

    public Slider healthBar;
    public Slider ammoBar;
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        knifeController = FindObjectOfType<KnifeController>();
        enemySpawner = FindObjectOfType<EnemySpawner>();

        healthBar.value = playerStats.currentHealth;
        ammoBar.value = knifeController.currentClip;

        UpdateEnemyCount();
    }

    void Update()
    {
        healthBar.value = playerStats.currentHealth;
        healthBar.maxValue = playerStats.maxHealth;
        ammoBar.value = knifeController.currentClip;
        goldText.text = playerStats.gold.ToString();
        levelText.text = playerStats.level + " (" + playerStats.experience + " / " + playerStats.experienceCap + " )";
        healthText.text = playerStats.currentHealth + " / " + playerStats.maxHealth;
        bulletText.text = knifeController.currentClip + " / " + knifeController.currentAmmo;

        if (playerStats.currentHealth <= 0)
        {
            DataToKeep.isPlayerDead = true;
            deathScreen.SetActive(true);
        }

        UpdateEnemyCount();
    }

     void UpdateEnemyCount()
    {
        if (enemySpawner != null)
        {
            int currentEnemyCount = enemySpawner.enemyPrefab.Count;
            if (currentEnemyCount > 0)
            {
                DataToKeep.enemyCounter = currentEnemyCount;
                enemyCountText.text = DataToKeep.enemyCounter.ToString() + " / " + currentEnemyCount;
            }
            else
            {
                DataToKeep.enemyCounter = 0;
                enemyCountText.text = "";
            }
        }
        else
        {
            DataToKeep.enemyCounter = 0;
            enemyCountText.text = "";
        }
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
        AudioManager.instance.SFXVolume(sfxSlider.value);
    }
}
