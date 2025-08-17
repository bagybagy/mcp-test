
using UnityEditor;
using UnityEngine;

public class SetupStep4_4
{
    [MenuItem("Gemini/Phase 4/Step 4.4: Setup EnemyHealth and Damage")]
    public static void Execute()
    {
        string prefabPath = "Assets/_Prefabs/Enemy.prefab";
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        if (prefab == null) { Debug.LogError("Enemy prefab not found."); return; }

        // Set tag
        prefab.tag = "Enemy";

        // Attach EnemyHealth script
        if (prefab.GetComponent<EnemyHealth>() == null) {
            prefab.AddComponent<EnemyHealth>();
        }

        EditorUtility.SetDirty(prefab);
        AssetDatabase.SaveAssets();
        Debug.Log("Enemy prefab updated with 'Enemy' tag and EnemyHealth script.");
    }
}
