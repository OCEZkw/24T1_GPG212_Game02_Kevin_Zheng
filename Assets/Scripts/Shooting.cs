using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform shootPoint; // Point where the bullets will be spawned
    public float shootSpeed = 100f; // Fixed speed for the bullets
    public float shootInterval = 0.5f; // Time interval between shots

    private bool canShoot = true; // Flag to track if the player can shoot

    void Update()
    {
        // Check for player input (e.g., mouse click or touch)
        if (Input.GetButtonDown("Fire1") && canShoot) // Change "Fire1" to the input you want to use
        {
            StartCoroutine(ShootRoutine());
        }
    }

    IEnumerator ShootRoutine()
    {
        canShoot = false; // Prevent shooting during the interval
        ShootBullet(); // Shoot a bullet

        yield return new WaitForSeconds(shootInterval); // Wait for the specified interval

        canShoot = true; // Allow shooting again
    }

    void ShootBullet()
    {
        // Instantiate a new bullet at the shoot point
        GameObject newBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

        // Get the Rigidbody2D component of the bullet
        Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();

        // Calculate the direction from the shooter to the mouse position
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
