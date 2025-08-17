
using UnityEditor;
using UnityEngine;

public class CheckStep4_3
{
    [MenuItem("Gemini/Checks/Check Step 4.3 - WeaponManager")]
    public static void Execute()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("[SELF CHECK] FAILED: Player object not found.");
            return;
        }

        WeaponManager manager = player.GetComponent<WeaponManager>();
        if (manager == null)
        {
            Debug.LogError("[SELF CHECK] FAILED: WeaponManager script is NOT attached to the Player.");
            return;
        }

        Debug.Log("[SELF CHECK] PASSED: WeaponManager script is attached to the Player.");

        // Check fields
        if (manager.initialWeaponPrefab != null)
        {
            Debug.Log("[SELF CHECK] PASSED: initialWeaponPrefab is assigned with: " + manager.initialWeaponPrefab.name);
        }
        else
        {
            Debug.LogError("[SELF CHECK] FAILED: initialWeaponPrefab is NOT assigned (null).");
        }

        if (manager.weaponSocket != null)
        {
            Debug.Log("[SELF CHECK] PASSED: weaponSocket is assigned with: " + manager.weaponSocket.name);
        }
        else
        {
            Debug.LogError("[SELF CHECK] FAILED: weaponSocket is NOT assigned (null).");
        }
    }
}
