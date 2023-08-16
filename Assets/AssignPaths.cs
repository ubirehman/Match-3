using SweetSugar.Scripts.MapScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignPaths : MonoBehaviour
{
    public Path path;
    public GameObject[] levels;


    [ContextMenu("Assign Paths")]
    public void AssignPath()
    {
        foreach(GameObject gobj in levels)
        {
            path.Waypoints.Add(gobj.transform.GetChild(0));
        }
    }
}
