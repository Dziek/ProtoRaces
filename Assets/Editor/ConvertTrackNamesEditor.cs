using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ConvertTrackNames))]
public class ConvertTrackNamesEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        ConvertTrackNames myScript = (ConvertTrackNames)target;
        if(GUILayout.Button("Change Z_ Track Names"))
        {
            myScript.ChangeNames();
        }
    }
}