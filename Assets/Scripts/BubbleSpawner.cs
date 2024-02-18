using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab; // Reference to the bubble prefab
    public float spawnInterval = 2f; // Time interval between bubble spawns
    public Vector2 spawnAreaSize = new Vector2(5f, 2f); // Size of the random spawn area

    void Start()
    {
        // Start spawning bubbles at regular intervals
        InvokeRepeating("SpawnBubble", 0f, spawnInterval);
    }

    void SpawnBubble()
    {
        // Calculate a random spawn position within the specified area
        Vector2 randomSpawnPosition = new Vector2(
            transform.position.x + Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
            transform.position.y + Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f)
        );

        // Instantiate a new bubble at the random spawn position
        Instantiate(bubblePrefab, randomSpawnPosition, Quaternion.identity);
    }

    // Draw Gizmos to visualize the spawn area
    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnAreaSize.x, spawnAreaSize.y, 0f));
    }
}
