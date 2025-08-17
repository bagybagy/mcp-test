
using UnityEditor;
using UnityEngine;

public class SetupStep4_2
{
    [MenuItem("Gemini/Phase 4/Step 4.2: Attach WeaponController")]
    public static void Execute()
    {
        string prefabPath = "Assets/_Prefabs/RotatingOrb.prefab";
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);

        if (prefab == null)
        {
            Debug.LogError("RotatingOrb prefab not found at: " + prefabPath);
            return;
        }

        if (prefab.GetComponent<WeaponController>() == null)
        {
            prefab.AddComponent<WeaponController>();
            EditorUtility.SetDirty(prefab);
            AssetDatabase.SaveAssets();
            Debug.Log("WeaponController script attached to RotatingOrb prefab successfully.");
        }
        else
        {
            Debug.Log("WeaponController script already attached to RotatingOrb prefab.");
        }
    }
}
