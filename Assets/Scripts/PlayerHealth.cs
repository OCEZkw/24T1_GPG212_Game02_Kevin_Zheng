using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public TextMeshProUGUI healthText; // Reference to the TextMeshPro Text object

    void Start()
    {
        Debug.Log("PlayerHealth Script Started");
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthText();

        // Check if the player is defeated
        if (currentHealth <= 0)
        {
            // Handle player defeat (e.g., game over, respawn, etc.)
            Debug.Log("Player Defeated!");
        }
    }

    void UpdateHealthText()
    {
        Debug.Log("Updating Health Text");
        // Update the TextMeshPro Text object with the current health value
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString();
        }
    }
}