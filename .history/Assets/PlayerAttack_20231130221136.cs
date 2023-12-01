    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float meleeSpeed;
    [SerializeField] private float damage;

    float timeUntilMelee = 1.0f;

    private void Update()
    {
        if (timeUntilMelee <= 0f)
        {
            if (Input.GetMouseButtonDown(0) && !DialogueManager.instance.dialogueIsPlaying)
            {
                AudioManager.instance.PlaySFX("Suara Pedang");
                anim.SetTrigger("Attack");
                timeUntilMelee = meleeSpeed;
            }
        }
        else
        {
            timeUntilMelee -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(damage);
        }
        else if (col.CompareTag("Prop"))
        {
            if (col.gameObject.TryGetComponent(out BreakableProps breakable))
            {
                breakable.TakeDamage(damage);
            }
        }
    }
}
