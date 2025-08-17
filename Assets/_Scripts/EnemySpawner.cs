
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 1f;
    public float spawnRadius = 20f;

    private Transform playerTransform;

    void Start()
    {
        // Find the player to spawn around
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Spawner could not find Player object! Make sure the player has the 'Player' tag.");
            // Disable self if player is not found
            this.enabled = false;
            return;
        }

        // Repeatedly call the SpawnEnemy method
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (playerTransform == null) return;

        // Calculate a random spawn position on a circle around the player
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector3 spawnPos = playerTransform.position + new Vector3(randomDirection.x, 0, randomDirection.y) * spawnRadius;

        // Instantiate the enemy
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
