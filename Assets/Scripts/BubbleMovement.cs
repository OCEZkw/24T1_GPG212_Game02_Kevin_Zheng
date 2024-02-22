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
    public int pointsOnHit = 1; // Points awarded when the bubble is hit

    private Score score;
    private GameObject bubble; // Reference to the bubble object
    private Collider2D fishCollider; // Reference to the fish collider
    private bool isMoving = true; // Flag to control movement state

    private void Start()
    {
        currentHealth = bubbleMaxHealth; // Initialize current health to max health
        score = GameObject.FindObjectOfType<Score>();
        bubble = transform.Find("Bubble").gameObject; // Adjust the name if needed
        fishCollider = GetComponent<Collider2D>(); // Get the fish collider
    }

    void Update()
    {
        if (isMoving)
        {
            // Move the bubble upwards
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }

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
                // Award different points based on the type of bubble
                if (gameObject.CompareTag("Bubble"))
                {
                    score.IncrementScore(1); // +1 point for Bubble
                }
                else if (gameObject.CompareTag("Bubble2"))
                {
                    score.IncrementScore(3); // +3 points for Bubble2
                }

                // Turn off the bubble
                SetBubbleActive(false);

                // Stop the movement
                isMoving = false;

                // Disable the fish collider
                fishCollider.enabled = false;

                // Start coroutine to destroy the fish after a delay
                StartCoroutine(DestroyFishAfterDelay(1f));
            }

            // Destroy the bullet
            Destroy(other.gameObject);
        }
    }

    // Function to set the bubble's active state
    private void SetBubbleActive(bool isActive)
    {
        bubble.SetActive(isActive);
    }

    // Coroutine to destroy the fish after a delay
    private IEnumerator DestroyFishAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Destroy the fish
        Destroy(gameObject);
    }
}
