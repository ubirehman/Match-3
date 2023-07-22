using UnityEditor;
using UnityEngine;

public class DuplicateAndRenameSOArrayElements : EditorWindow
{
    [MenuItem("MyTools/Duplicate and Rename SO Array Elements")]
    private static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(DuplicateAndRenameSOArrayElements));
    }

    private ScriptableObject[] sourceArray;

    private void OnGUI()
    {
        GUILayout.Label("Source ScriptableObject Array", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.BeginVertical();

        sourceArray = EditorGUILayout.ObjectField("Source Array", sourceArray, typeof(ScriptableObject), true) as ScriptableObject[];

        EditorGUILayout.EndVertical();

        EditorGUILayout.Space();

        if (GUILayout.Button("Duplicate and Rename"))
        {
            if (sourceArray != null && sourceArray.Length > 0)
            {
                DuplicateAndRenameElements();
            }
        }
    }

    private void DuplicateAndRenameElements()
    {
        foreach (ScriptableObject originalSO in sourceArray)
        {
            ScriptableObject newSO = Instantiate(originalSO);
            newSO.name = "New_" + originalSO.name;
            AssetDatabase.AddObjectToAsset(newSO, AssetDatabase.GetAssetPath(originalSO));
            AssetDatabase.SaveAssets();
        }
    }
}
