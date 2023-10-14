using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    public CharacterScriptableObject characterData;
    [SerializeField]
    public float currentHealth;
    [SerializeField]
    public float currentMoveSpeed;

    [Header("I-Frames")]
    [SerializeField]
    public float invincibilityDuration;
    public float invincibilityTimer;
    public bool isInvincible;

    [SerializeField]
    public int gold;

<<<<<<< Updated upstream
    public TMP_Text goldText;
    public TMP_Text levelText;
    public TMP_Text healthText;

    public PlayerLevel level;
=======
    private PlayerLevel level;
    public int playerLevel;

    private KnifeController knifeController;

    public static PlayerStats Instance; 
>>>>>>> Stashed changes

    void Start()
    {
        level = FindObjectOfType<PlayerLevel>();
<<<<<<< Updated upstream
=======
        knifeController = FindObjectOfType<KnifeController>();
        playerLevel = level.level;
    }

    [JsonIgnore] // This field will be excluded from JSON serialization
    public float CurrentHealth
    {
        get { return currentHealth; }
    }

    [JsonIgnore] // This field will be excluded from JSON serialization
    public float CurrentMoveSpeed
    {
        get { return currentMoveSpeed; }
>>>>>>> Stashed changes
    }

    public void IncreaseGold(int amount)
    {
        gold += amount; 
    }

    void Update()
    {
        if(invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }
        else if(isInvincible)
        {
            isInvincible = false;
<<<<<<< Updated upstream
        }

        goldText.text = "Gold : " + gold;
        levelText.text = "Level : " + level.level + " (" + level.experience + " / " + level.experienceCap + " )";
        healthText.text = "HP : " + currentHealth;

=======
        } 
>>>>>>> Stashed changes
    }

    void Awake()
    {
        currentHealth = characterData.MaxHealth;
        currentMoveSpeed = characterData.MoveSpeed;
    } 

    public void TakeDamage(float dmg)
    {
        if(!isInvincible)
        {
            currentHealth -= dmg;

            invincibilityTimer = invincibilityDuration;
            isInvincible = true;

            if(currentHealth <= 0)
            {
                Kill();
            }
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    public void RestoreHealth(float amount)
    {
        if(currentHealth < characterData.MaxHealth)
        {
            currentHealth += amount;

            if(currentHealth > characterData.MaxHealth)
            {
                currentHealth = characterData.MaxHealth;
            }
        }
    }
}
