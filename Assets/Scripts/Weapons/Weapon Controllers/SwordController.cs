using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : WeaponController
{
    [SerializeField] private Animator anim;

    protected override void Start()
    {
        base.Start();
    }

    protected override void MidSwordAttack()
    {
        base.MidSwordAttack();

        // Get the mouse position in world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // Calculate the angle between the sword and the mouse position
        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        // Rotate the sword towards the mouse position
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // Trigger the attack animation
        anim.SetTrigger("Attack");
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(weaponData.Damage);
        }
    }
}
