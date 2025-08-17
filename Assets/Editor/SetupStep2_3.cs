
using UnityEditor;
using UnityEngine;

public class SetupStep2_3
{
    [MenuItem("Gemini/Step 2.3: Setup Follow Camera")]
    public static void Execute()
    {
        var player = GameObject.Find("Player");
        var mainCamera = GameObject.Find("Main Camera");

        if (player == null || mainCamera == null)
        {
            Debug.LogError("Player or Main Camera not found in the scene.");
            return;
        }

        // Parent camera to player
        mainCamera.transform.SetParent(player.transform);

        // Adjust camera's local transform
        mainCamera.transform.localPosition = new Vector3(0, 10, -10);
        mainCamera.transform.localRotation = Quaternion.Euler(45, 0, 0);

        Debug.Log("Step 2.3 complete: Camera is now a child of Player and its transform is adjusted.");
    }
}
