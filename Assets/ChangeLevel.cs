using System.Collections;
using System.Collections.Generic;
using SweetSugar.Scripts.Level;
using SweetSugar.Scripts.TargetScripts.TargetEditor;
using UnityEditor;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    [SerializeField] int levelNumber = 101;

    public LevelContainer[] levelContainer;
    public TargetLevel[] targetLevel;


    [ContextMenu("Change Name")]
    public void ChangeName()
    {
        for (int i = 0; i < levelContainer.Length; i++)
        {
            var path = AssetDatabase.GetAssetPath(levelContainer[i]);
            AssetDatabase.RenameAsset(path, "Level_" + (levelNumber + i));

            var path1 = AssetDatabase.GetAssetPath(targetLevel[i]);
            AssetDatabase.RenameAsset(path1, "TargetLevel" + (levelNumber + i));
        }
    }
}
