using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObjects enemyData;
    private EnemySpawner enemySpawner;

    float currentMoveSpeed;
    float currentHealth;
    float currentDamage;

    Rigidbody2D rb; // Rigidbody2D untuk enemy

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;

        rb = GetComponent<Rigidbody2D>(); // Mengambil komponen Rigidbody2D
    }

    public void TakeDamage(float dmg, Vector2 sourcePosition, float knockbackForce = 10f, float knockbackDuration = 0.2f)
    {
        Debug.Log("Enemy Taking Damage!");
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            enemySpawner.RemoveEnemy(gameObject);
            Kill();
        }

        if (knockbackForce > 0)
        {
            // Hitung arah knockback
            Vector2 dir = (Vector2)transform.position - sourcePosition;
            dir.Normalize(); // Normalisasi arah agar vektor memiliki panjang 1

            // Terapkan gaya knockback ke musuh
            rb.AddForce(dir * knockbackForce, ForceMode2D.Impulse);

            // Mulai coroutine untuk menghentikan knockback setelah durasi tertentu (optional)
            StartCoroutine(StopKnockbackAfterDuration(knockbackDuration));
        }
    }

    // Coroutine untuk menghentikan knockback setelah durasi tertentu (optional)
    private IEnumerator StopKnockbackAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        rb.velocity = Vector2.zero; // Hentikan kecepatan musuh setelah knockback berakhir
    }


    public void Kill()
    {
        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerMovement player = col.gameObject.GetComponent<PlayerMovement>();
            if (player != null && player.isDashing)
            {
                Rigidbody2D playerRb = col.gameObject.GetComponent<Rigidbody2D>();
                if (playerRb != null)
                {
                    playerRb.isKinematic = true; // Menonaktifkan Rigidbody pemain saat sedang dash
                    StartCoroutine(ReactivatePlayerRigidbody(playerRb)); // Mengaktifkan kembali Rigidbody pemain setelah jeda
                }

                gameObject.SetActive(false); // Menonaktifkan game object musuh
                Invoke("ReactivateEnemy", 0.2f); // Menjalankan metode untuk mengaktifkan kembali musuh setelah jeda
            }
            else
            {
                PlayerStats playerStats = col.gameObject.GetComponent<PlayerStats>();
                if (playerStats != null)
                {
                    playerStats.TakeDamage(currentDamage);
                }

                // Menggerakkan musuh mundur sedikit
                Vector2 direction = transform.position - col.transform.position;
                rb.velocity = direction.normalized * currentMoveSpeed * 10f * Time.deltaTime;
            }
        }
    }

    // Method to reactivate the player's Rigidbody after a delay
    private IEnumerator ReactivatePlayerRigidbody(Rigidbody2D playerRb)
    {
        yield return new WaitForSeconds(0.2f); // Adjust the delay as needed
        if (playerRb != null)
        {
            playerRb.isKinematic = false; // Mengaktifkan kembali Rigidbody pemain setelah jeda
            Debug.Log("Player Rigidbody Reactivated");
        }  
    }

    // Method to reactivate the enemy after a delay
    private void ReactivateEnemy()
    {
        gameObject.SetActive(true);
    }
}
