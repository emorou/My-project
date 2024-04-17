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

    public Slider healthBar;
    public Slider ammoBar;
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        knifeController = FindObjectOfType<KnifeController>();
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

        if(playerStats.currentHealth <= 0)
        {
            DataToKeep.isPlayerDead = true;
            // Time.timeScale = 0f;
            deathScreen.SetActive(true); 
        }
    }
    
    public void WinButton()
    {
        DataPersistenceManager.instance.SaveGame();

        SceneManager.LoadSceneAsync("Lobby New");
    }
    
    public void Level1Button()
    {   
        DataPersistenceManager.instance.SaveGame();
       
        SceneManager.LoadSceneAsync("Level 1 New");
        
    }

    public void DeathGameButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("Lobby New");
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
