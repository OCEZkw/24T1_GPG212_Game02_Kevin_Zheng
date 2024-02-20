using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform shootPoint; // Point where the bubbles and bullets will be spawned
    public float shootSpeed = 100f; // Fixed speed for the bubbles

    void Update()
    {
        // Check for player input (e.g., mouse click or touch)
        if (Input.GetButtonDown("Fire1")) // Change "Fire1" to the input you want to use
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        // Instantiate a new bullet at the shoot point
        GameObject newBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

        // Get the Rigidbody component of the bullet
        Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();

        // Calculate the direction from shooter to mouse position
        Vector2 shootDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - shootPoint.position);

        shootDirection.Normalize();

        // Apply a fixed speed to the bullet in the calculated direction
        bulletRb.velocity = shootDirection * shootSpeed;

        // Calculate the angle in degrees from the direction vector
        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
        angle += 180f;


        // Rotate the bullet to face the direction it's moving
        newBullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


    }
}
