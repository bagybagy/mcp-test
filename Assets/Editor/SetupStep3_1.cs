
using UnityEditor;
using UnityEngine;

public class SetupStep3_1
{
    [MenuItem("Gemini/Step 3.1: Create Enemy Prefab")]
    public static void Execute()
    {
        var enemyObject = GameObject.Find("Enemy");
        if (enemyObject == null)
        {
            Debug.LogError("Scene object named 'Enemy' not found.");
            return;
        }

        // Create and apply red material
        var enemyMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        enemyMaterial.color = Color.red;
        if (!AssetDatabase.IsValidFolder("Assets/_Materials"))
        {
            AssetDatabase.CreateFolder("Assets", "_Materials");
        }
        AssetDatabase.CreateAsset(enemyMaterial, "Assets/_Materials/Enemy_Mat.mat");
        enemyObject.GetComponent<Renderer>().material = enemyMaterial;

        // Create prefab
        if (!AssetDatabase.IsValidFolder("Assets/_Prefabs"))
        {
            AssetDatabase.CreateFolder("Assets", "_Prefabs");
        }
        string prefabPath = "Assets/_Prefabs/Enemy.prefab";
        PrefabUtility.SaveAsPrefabAssetAndConnect(enemyObject, prefabPath, InteractionMode.UserAction);

        // Delete from scene
        Object.DestroyImmediate(enemyObject);

        Debug.Log("Step 3.1 complete: Enemy prefab created and scene object removed.");
    }
}
