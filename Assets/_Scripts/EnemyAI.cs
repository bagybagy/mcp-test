
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Transform playerTransform;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player object with tag 'Player' not found.");
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {
            // Determine the direction to the player
            Vector3 direction = playerTransform.position - transform.position;
            direction.y = 0; // Don't tilt up/down

            // Rotate to look at the player
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }

            // Move forward
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }
}
