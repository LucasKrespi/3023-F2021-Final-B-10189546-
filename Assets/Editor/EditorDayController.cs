using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(DayController))]
public class EditorDayController : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        DayController dayController = (DayController)target;

        if (EditorGUILayout.LinkButton("AssingDays"))
        {
            dayController.ConstructDay();
        }
    }
}
