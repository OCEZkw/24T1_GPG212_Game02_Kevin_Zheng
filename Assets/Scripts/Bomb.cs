using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bomb : MonoBehaviour
{
    public int damage = 1; // Damage to player when hit by a bullet

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the bomb is hit by a GameObject tagged as "Bullet"
        if (other.CompareTag("Bullet"))
        {
            // Get the PlayerHealth component from the player object
            PlayerHealth playerHealth = other.gameObject.GetComponentInParent<PlayerHealth>();

            // Check if the playerHealth component is found
            if (playerHealth != null)
            {
                // Reduce player health
                playerHealth.TakeDamage(damage);
            }

            // Destroy the bomb when hit by a bullet
            Destroy(gameObject);
        }
    }
}
