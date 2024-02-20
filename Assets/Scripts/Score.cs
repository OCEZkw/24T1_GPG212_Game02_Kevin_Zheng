using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private int score = 0;
    public TMP_Text scoreText; 

    // Method to increment the score
    public void IncrementScore()
    {
        score++;
        UpdateScoreUI();
    }

    // Method to update the score UI
    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }
}
