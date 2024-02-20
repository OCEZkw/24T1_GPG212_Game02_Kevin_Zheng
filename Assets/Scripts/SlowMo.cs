using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMo : MonoBehaviour
{
    // Adjust this value to set the duration of the slow motion effect
    public float slowMotionDuration = 2f;
    private bool isSlowingDown = false;

    public Shooting shootingScript;

    void Update()
    {
        // Check for right mouse button click
        if (Input.GetMouseButtonDown(1)) // Right mouse button
        {
            ActivateSpecialAbility();
        }

        // Check if we are currently slowing down time
        if (isSlowingDown)
        {
            SlowDownTime();
        }
    }

    void ActivateSpecialAbility()
    {
        // Trigger slow motion effect
        Time.timeScale = 0.5f;
        isSlowingDown = true;

        // Start a coroutine to return time back to normal after duration
        StartCoroutine(ReturnToNormalTime());
    }

    void SlowDownTime()
    {
        // If bulletScript is not null, adjust the bullet speed
        if (shootingScript != null)
        {
            // Ensure the bullet speed remains the same during slow motion
            shootingScript.shootSpeed *= 10f;
        }
    }

    IEnumerator ReturnToNormalTime()
    {
        // Wait for the duration of the slow motion effect
        yield return new WaitForSecondsRealtime(slowMotionDuration);

        // Reset time back to normal
        Time.timeScale = 1f;
        isSlowingDown = false;
    }
}
