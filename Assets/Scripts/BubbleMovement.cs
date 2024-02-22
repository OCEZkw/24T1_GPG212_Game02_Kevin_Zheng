using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BubbleMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the bubble's upward movement
    public float destroyHeight = 10f; // Height at which the bubble will be destroyed
    public int bubbleMaxHealth = 2; // Maximum health of the bubble
    private int currentHealth; // Current health of the bubble

    private Score score;

    private void Start()
    {
        currentHealth = bubbleMaxHealth; // Initialize current health to max health
        score = GameObject.FindObjectOfType<Score>();
    }

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
        if (other.CompareTag("Bullet"))
        {
            // Reduce the bubble's health
            currentHealth--;

            // Check if the bubble is destroyed
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                // Call the IncrementScore method from the ScoreManager script
                score.IncrementScore();
            }

            // Destroy the bullet
            Destroy(other.gameObject);
        }
    }
}
