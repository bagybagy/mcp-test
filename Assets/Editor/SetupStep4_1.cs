
using UnityEditor;
using UnityEngine;

public class SetupStep4_1
{
    [MenuItem("Gemini/Phase 4/Step 4.1: Create and Verify Weapon Prefab")]
    public static void Execute()
    {
        var sphere = GameObject.Find("Sphere");
        if (sphere == null)
        {
            Debug.LogError("Scene object named 'Sphere' not found.");
            return;
        }

        // Rename and scale
        sphere.name = "RotatingOrb";
        sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        // Set collider to trigger
        var collider = sphere.GetComponent<SphereCollider>();
        if (collider != null) collider.isTrigger = true;

        // Create and apply blue material
        var weaponMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        weaponMaterial.color = Color.blue;
        if (!AssetDatabase.IsValidFolder("Assets/_Materials")) AssetDatabase.CreateFolder("Assets", "_Materials");
        AssetDatabase.CreateAsset(weaponMaterial, "Assets/_Materials/Weapon_Mat.mat");
        sphere.GetComponent<Renderer>().material = weaponMaterial;

        // Create prefab
        if (!AssetDatabase.IsValidFolder("Assets/_Prefabs")) AssetDatabase.CreateFolder("Assets", "_Prefabs");
        string prefabPath = "Assets/_Prefabs/RotatingOrb.prefab";
        PrefabUtility.SaveAsPrefabAssetAndConnect(sphere, prefabPath, InteractionMode.UserAction);
        Debug.Log("[SELF CHECK] Step 4.1: Prefab created at " + prefabPath);

        // Self-check the created prefab
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        if (prefab != null)
        {
            var prefabCollider = prefab.GetComponent<SphereCollider>();
            if (prefabCollider != null && prefabCollider.isTrigger)
            {
                Debug.Log("[SELF CHECK] Step 4.1: isTrigger verification PASSED.");
            }
            else
            {
                Debug.LogError("[SELF CHECK] Step 4.1: isTrigger verification FAILED.");
            }
        }
        else
        {
            Debug.LogError("[SELF CHECK] Step 4.1: Prefab loading for verification FAILED.");
        }

        // Delete from scene
        Object.DestroyImmediate(sphere);
    }
}
