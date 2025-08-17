
using UnityEditor;
using UnityEngine;

public class SetupStep3_3
{
    [MenuItem("Gemini/Step 3.3: Assign Prefab to Spawner")]
    public static void Execute()
    {
        // Find the spawner in the scene
        GameObject spawnerObject = GameObject.Find("EnemySpawner");
        if (spawnerObject == null)
        {
            Debug.LogError("EnemySpawner object not found in the scene.");
            return;
        }

        EnemySpawner spawnerComponent = spawnerObject.GetComponent<EnemySpawner>();
        if (spawnerComponent == null)
        {
            Debug.LogError("EnemySpawner script not found on the EnemySpawner object.");
            return;
        }

        // Load the enemy prefab
        string prefabPath = "Assets/_Prefabs/Enemy.prefab";
        GameObject enemyPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        if (enemyPrefab == null)
        {
            Debug.LogError("Enemy prefab not found at: " + prefabPath);
            return;
        }

        // Assign the prefab to the script's public field
        spawnerComponent.enemyPrefab = enemyPrefab;
        EditorUtility.SetDirty(spawnerComponent);

        Debug.Log("Step 3.3 complete: Assigned Enemy prefab to EnemySpawner.");
    }
}
