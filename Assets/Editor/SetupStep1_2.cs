using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SetupStep1_2
{
    public static void Run()
    {
        // Create folders
        if (!AssetDatabase.IsValidFolder("Assets/_Scripts")) AssetDatabase.CreateFolder("Assets", "_Scripts");
        if (!AssetDatabase.IsValidFolder("Assets/_Prefabs")) AssetDatabase.CreateFolder("Assets", "_Prefabs");
        if (!AssetDatabase.IsValidFolder("Assets/_Materials")) AssetDatabase.CreateFolder("Assets", "_Materials");
        if (!AssetDatabase.IsValidFolder("Assets/_Models")) AssetDatabase.CreateFolder("Assets", "_Models");
        if (!AssetDatabase.IsValidFolder("Assets/_Textures")) AssetDatabase.CreateFolder("Assets", "_Textures");

        // New scene
        var scene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);

        // Ground plane
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ground.name = "Ground";
        ground.transform.position = new Vector3(0, 0, 0);
        ground.transform.localScale = new Vector3(100, 1, 100);

        // Ground material
        Material groundMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        groundMaterial.color = new Color(128/255f, 128/255f, 128/255f);
        AssetDatabase.CreateAsset(groundMaterial, "Assets/_Materials/Ground_Mat.mat");
        ground.GetComponent<Renderer>().material = groundMaterial;

        // Directional Light
        GameObject lightGameObject = GameObject.Find("Directional Light");
        if (lightGameObject != null)
        {
            lightGameObject.transform.rotation = Quaternion.Euler(50, -30, 0);
            lightGameObject.GetComponent<Light>().shadows = LightShadows.Soft;
        }

        // Save scene
        EditorSceneManager.SaveScene(scene, "Assets/Scenes/GameScene.unity");
    }
}
