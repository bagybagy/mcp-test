using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject initialWeaponPrefab;
    public Transform weaponSocket;

    void Start()
    {
        if (initialWeaponPrefab != null && weaponSocket != null)
        {
            // Instantiate the weapon with an offset so it can orbit
            Vector3 initialPosition = weaponSocket.position + new Vector3(1f, 0, 0);
            Instantiate(initialWeaponPrefab, initialPosition, weaponSocket.rotation, weaponSocket);
        }
    }
}