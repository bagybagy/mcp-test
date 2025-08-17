
using UnityEditor;
using UnityEngine;

public class SetupStep1_2_Part2
{
    [MenuItem("Gemini/Step 1.2: Create Material and Set Light")]
    public static void Execute()
    {
        // Find the Ground object
        var ground = GameObject.Find("Ground");
        if (ground == null)
        {
            Debug.LogError("Could not find GameObject named 'Ground' in the scene.");
            return;
        }

        // Create and assign gray material
        var groundMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        groundMaterial.color = new Color(128f / 255f, 128f / 255f, 128f / 255f);
        
        if (!AssetDatabase.IsValidFolder("Assets/_Materials"))
        {
            AssetDatabase.CreateFolder("Assets", "_Materials");
        }
        AssetDatabase.CreateAsset(groundMaterial, "Assets/_Materials/Ground_Mat.mat");
        ground.GetComponent<Renderer>().material = groundMaterial;

        // Adjust Directional Light
        var light = GameObject.Find("Directional Light");
        if (light != null)
        {
            light.transform.rotation = Quaternion.Euler(50, -30, 0);
        }

        Debug.Log("Step 1.2 (Part 2) complete: Material created and light adjusted.");
        Debug.Log("Please save the scene as 'GameScene' to complete this step.");
    }
}
