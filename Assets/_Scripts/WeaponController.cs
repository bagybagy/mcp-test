using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public float rotationSpeed = 100f;
    private Transform playerTransform;

    void Start()
    {
        if (transform.parent != null)
        {
            playerTransform = transform.parent;
        }
        else
        {
            Debug.LogError("Weapon needs a parent object to rotate around!");
            this.enabled = false;
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {
            transform.RotateAround(playerTransform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(1);
            }
        }
    }
}