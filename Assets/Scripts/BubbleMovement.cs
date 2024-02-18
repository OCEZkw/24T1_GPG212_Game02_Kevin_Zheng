using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the bubble's upward movement
    public float destroyHeight = 10f; // Height at which the bubble will be destroyed

    void Update()
    {
        // Move the bubble upwards
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);

        // Check if the bubble has reached the destroy height
        if (transform.position.y >= destroyHeight)
        {
            // Destroy the bubble when it goes beyond the destroy height
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the bubble collides with a GameObject tagged as "Bullet"
        if (other.CompareTag("Bullet"))
        {
            // Destroy the bubble when it collides with a bullet
            Destroy(gameObject);

            // You can add additional logic here, such as updating the score or playing a sound
        }
    }
}
