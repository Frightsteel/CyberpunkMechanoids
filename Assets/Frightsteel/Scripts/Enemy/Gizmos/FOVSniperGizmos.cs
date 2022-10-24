using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FOVSniper))]
public class FOVSniperGizmos : FieldOfViewGizmos
{
    protected override void OnSceneGUI()
    {
        base.OnSceneGUI();

        FOVSniper fov = (FOVSniper)target;

        Handles.color = Color.blue;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.EscapeRadius);
    }
}
