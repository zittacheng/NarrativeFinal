using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TextControl))]
public class Editor_TextControl : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        TextControl TC = (TextControl)target;
        if (GUILayout.Button("Assign"))
        {
            Undo.RecordObject(TC, "Assign");
            TC.EditorAssign();
        }
    }
}
