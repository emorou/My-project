using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBehaviour : ProjectileWeaponBehaviour
{

    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        // transform.position += direction * weaponData.Speed * Time.deltaTime;  
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = -Camera.main.transform.position.z; // Set the correct Z distance from the camera
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // Calculate the direction from the player to the mouse cursor
            Vector3 direction = worldMousePosition - transform.position;
            direction.z = 0f; // Make sure Z is 0 since you are working in 2D

            // Update player rotation and scale based on the direction
            
    }
    }
}
