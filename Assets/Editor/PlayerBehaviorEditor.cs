using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(PlayerBehaviour))]
public class PlayerBehaviourEditor : Editor
{
   public override void OnInspectorGUI()
    {
        PlayerBehaviour pb = (PlayerBehaviour)target;
        pb.moveSpeed = EditorGUILayout.FloatField("Player Move Speed", pb.moveSpeed);
    }
}
