using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base script of all projectile behaviours [To be placed on a prefab of a weapon that is a projectile]
/// </summary>
public class ProjectileWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData;

    protected Vector3 direction;
    public float destroyAfterSeconds;

    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownReduction;

    void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownReduction = weaponData.CooldownDurationRanged;
    }
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    public void DirectionChecker(Vector3 dir)
    {
        // Check if the mouse button is held down (you can change this condition as needed)
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = -Camera.main.transform.position.z; // Set the correct Z distance from the camera
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // Calculate the direction from the player to the mouse cursor
            Vector3 direction = worldMousePosition - transform.position;
            direction.z = 0f; // Make sure Z is 0 since you are working in 2D

            // Update player rotation and scale based on the direction
        // direction = dir;

        // float dirx = direction.x;
        // float diry = direction.y;

        // Vector3 scale = transform.localScale;
        // Vector3 rotation = transform.rotation.eulerAngles;

        // if (dirx < 0 && diry == 0) //left
        // {
        //     scale.x = scale.x * -1;
        //     scale.y = scale.y * -1;
        // }
        // else if (dirx == 0 && diry < 0) //down
        // {
        //     scale.y = scale.y * -1;
        // }
        // else if (dirx == 0 && diry > 0) //up
        // {
        //     scale.x = scale.x * -1;
        // }
        // else if (dirx > 0 && diry > 0) //right up
        // {
        //     rotation.z = 0f;
        // }
        // else if (dirx > 0 && diry < 0) //right down
        // {
        //     rotation.z = -90f;
        // }
        // else if (dirx < 0 && diry > 0) //left up
        // {
        //     scale.x = scale.x * -1;
        //     scale.y = scale.y * -1;
        //     rotation.z = -90f;
        // }
        // else if (dirx < 0 && diry < 0) //left down
        // {
        //     scale.x = scale.x * -1;
        //     scale.y = scale.y * -1;
        //     rotation.z = 0f;
        // }

        // transform.localScale = scale;
        // transform.rotation = Quaternion.Euler(rotation);    //Can't simply set the vector because cannot convert
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Enemy"))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage);
        }
        else if(col.CompareTag("Prop"))
        {
            if(col.gameObject.TryGetComponent(out BreakableProps breakable))
            {
                breakable.TakeDamage(currentDamage);
            }
        }    
    }
}
