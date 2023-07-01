using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class SetPreserveAspect : MonoBehaviour
{
    Image[] images = FindObjectsOfType<Image>();
    void Start()
    {
        // Find all objects with Image component in the scene
        images = FindObjectsOfType<Image>();
        // Loop through each image and set preserveAspect to true
        foreach (Image image in images)
        {
            image.preserveAspect = true;
        }
    }
}
