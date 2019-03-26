using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(RangeObserver_AI))]
public class RangeObserver_AIScrpitEditor : Editor {
    public override void OnInspectorGUI()
    {
        RangeObserver_AI rangeObserver_AI = target as RangeObserver_AI;

#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
        EditorGUIUtility.LookLikeInspector();
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos

        EditorGUILayout.PropertyField(serializedObject.FindProperty("onInRange"));

        rangeObserver_AI.noMaxRange = EditorGUILayout.Toggle("No Max Range", rangeObserver_AI.noMaxRange);
        if (!rangeObserver_AI.noMaxRange)
        {
            EditorGUILayout.FloatField("Max Range", rangeObserver_AI.maxRange);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("onTooFar"));

        }
        rangeObserver_AI.noMinRange = EditorGUILayout.Toggle("No Min Range", rangeObserver_AI.noMinRange);
        if (!rangeObserver_AI.noMinRange)
        {
            EditorGUILayout.FloatField("Min Range", rangeObserver_AI.minRange);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("onTooClose"));
        }

        if (GUI.changed) serializedObject.ApplyModifiedProperties();
    }
}