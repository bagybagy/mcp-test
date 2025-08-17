
using UnityEditor;
using UnityEngine;

public class SetupStep3_2
{
    [MenuItem("Gemini/Step 3.2: Attach AI Script to Prefab")]
    public static void Execute()
    {
        string prefabPath = "Assets/_Prefabs/Enemy.prefab";
        GameObject enemyPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);

        if (enemyPrefab == null)
        {
            Debug.LogError("Enemy prefab not found at: " + prefabPath);
            return;
        }

        // Add the EnemyAI script if it doesn't already exist
        if (enemyPrefab.GetComponent<EnemyAI>() == null)
        {
            enemyPrefab.AddComponent<EnemyAI>();
            PrefabUtility.SavePrefabAsset(enemyPrefab);
            Debug.Log("EnemyAI script attached to Enemy prefab successfully.");
        }
        else
        {
            Debug.Log("EnemyAI script already attached to Enemy prefab.");
        }
    }
}
