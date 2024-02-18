using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the bullet collides with a GameObject tagged as "Bubble"
        if (other.CompareTag("Bubble"))
        {
            // Destroy the bullet when it collides with a bubble
            Destroy(gameObject);
        }

        // Check if the bullet collides with a GameObject tagged as "BulletDestroy"
        if (other.CompareTag("BulletDestroyer"))
        {
            // Destroy the bullet when it collides with a BulletDestroy object
            Destroy(gameObject);
        }
    }
}
