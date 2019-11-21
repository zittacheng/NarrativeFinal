using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TextUnit))]
[CanEditMultipleObjects]
public class Editor_TextUnit : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        TextUnit TU = (TextUnit)target;
        if (GUILayout.Button("Assign"))
        {
            Undo.RecordObject(TU, "Assign");
            TU.EditorAssign();
        }
    }
}
