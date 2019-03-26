using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(RangeObserver_AI))]
public class RangeObserver_AIScrpitEditor : Editor {

    private bool maxValueChanged;
    private float lastValueMaxRange;

    private bool minValueChanged;
    private float lastValueMinRange;

    public override void OnInspectorGUI()
    {
        RangeObserver_AI rangeObserver_AI = target as RangeObserver_AI;

#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
        EditorGUIUtility.LookLikeInspector();
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
        //TARGET
        EditorGUILayout.PropertyField(serializedObject.FindProperty("target"));


        //MAX DISTANCE//////////////////////
        bool before = rangeObserver_AI.noMaxRange;
        rangeObserver_AI.noMaxRange = EditorGUILayout.Toggle("No Max Range", rangeObserver_AI.noMaxRange);
        maxValueChanged = before != rangeObserver_AI.noMaxRange;

        if (rangeObserver_AI.noMaxRange)
        {
            if(maxValueChanged)
                lastValueMaxRange = rangeObserver_AI.maxRange;
            rangeObserver_AI.maxRange = float.NegativeInfinity;
        }
        else
        {
            if(maxValueChanged)
                rangeObserver_AI.maxRange = lastValueMaxRange;
            rangeObserver_AI.maxRange = EditorGUILayout.FloatField("Max Range", rangeObserver_AI.maxRange);
        }

        //MIN DISTANCE//////////////////////
        before = rangeObserver_AI.noMinRange;
        rangeObserver_AI.noMinRange = EditorGUILayout.Toggle("No Min Range", rangeObserver_AI.noMinRange);
        minValueChanged = before != rangeObserver_AI.noMinRange;

        if (rangeObserver_AI.noMinRange)
        {
            if(minValueChanged)
                lastValueMinRange = rangeObserver_AI.minRange;
            rangeObserver_AI.minRange = float.PositiveInfinity;
        }
        else
        {
            if(minValueChanged)
                rangeObserver_AI.minRange = lastValueMinRange;
            rangeObserver_AI.minRange = EditorGUILayout.FloatField("Min Range", rangeObserver_AI.minRange);
        }

        //CallBacks////////////////////////
        EditorGUILayout.PropertyField(serializedObject.FindProperty("onTooFar"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("onInRange"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("onTooClose"));
        
        //Update gui
        if (GUI.changed) serializedObject.ApplyModifiedProperties();
    }
}