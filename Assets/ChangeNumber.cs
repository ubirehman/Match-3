using System.Collections;
using System.Collections.Generic;
using SweetSugar.Scripts.MapScripts;
using UnityEngine;

[ExecuteInEditMode]
public class ChangeNumber : MonoBehaviour
{
    public int numberToIncrement = 201;
    [ContextMenu("Change Number")]
    void ChangeNumbers()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<MapLevel>().Number = i + numberToIncrement;
            transform.GetChild(i).gameObject.name = "Level" + (i + numberToIncrement).ToString();
        }
    }
}
