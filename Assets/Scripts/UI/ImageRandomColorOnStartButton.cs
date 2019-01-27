using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
[CustomEditor(typeof(ImageRandomColorOnStart))]
public class ImageRandomColorOnStartButton : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ImageRandomColorOnStart script = (ImageRandomColorOnStart) target;
        if (GUILayout.Button("Generate Random Color"))
        {
            script.GenerateRandomColor();
        }
    }
}
#endif