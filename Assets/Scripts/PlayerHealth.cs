using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public TMP_Text livesText;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateLivesText();

    }

    public void TakeDamage()
    {
        currentHealth--;
        Debug.Log("Player health decreased. Current health: " + currentHealth);
        UpdateLivesText();
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void UpdateLivesText()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + currentHealth;
        }
    }

    private void Die()
    {
        SceneManager.LoadScene("GameOver");
        Debug.Log("Player died!");
    }
}
