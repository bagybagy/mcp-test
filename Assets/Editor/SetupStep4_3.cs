
using UnityEditor;
using UnityEngine;

public class SetupStep4_3
{
    [MenuItem("Gemini/Phase 4/Step 4.3: Setup WeaponManager")]
    public static void Execute()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) { Debug.LogError("Player not found."); return; }

        // Attach WeaponManager script
        WeaponManager manager = player.GetComponent<WeaponManager>();
        if (manager == null) manager = player.AddComponent<WeaponManager>();

        // Assign fields
        manager.weaponSocket = player.transform;
        manager.initialWeaponPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/_Prefabs/RotatingOrb.prefab");

        EditorUtility.SetDirty(manager);
        Debug.Log("WeaponManager setup on Player complete. Prefab and socket assigned.");
    }
}
