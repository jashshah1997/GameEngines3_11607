using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(EncounterManager))]
public class EncounterMangerEditor : Editor
{
   public override void OnInspectorGUI()
    {
        EncounterManager em = (EncounterManager)target;
        em.startPlayerHealth = EditorGUILayout.IntSlider("Start Player HP", em.startPlayerHealth, 10, 100);
        em.startEnemyHealth = EditorGUILayout.IntSlider("Start Enemy HP", em.startEnemyHealth, 10, 50);
    }
}
