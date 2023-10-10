using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float meleeSpeed;
    [SerializeField] private GameObject animationPivot;
    [SerializeField] private float damage;

    float timeUntilMelee = 0.5f;

    private void Update()
    {
        if (timeUntilMelee <= 0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                Vector3 direction = mousePosition - animationPivot.transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                // Rotate the AnimationPivot GameObject
                animationPivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

                // Trigger the "rotate" animation
                anim.SetTrigger("Attack");

                // Perform your attack logic here
                // ...

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
        else if(col.CompareTag("Prop"))
        {
            if(col.gameObject.TryGetComponent(out BreakableProps breakable))
            {
                breakable.TakeDamage(damage);
            }
        }   
    }
}
