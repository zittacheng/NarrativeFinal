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
            PrefabUtility.RecordPrefabInstancePropertyModifications(TU);
        }
        if (GUILayout.Button("NextUnit"))
        {
            Undo.RecordObject(TU, "NextUnit");
            TU.EditorNextUnit();
            PrefabUtility.RecordPrefabInstancePropertyModifications(TU);
        }
    }
}
