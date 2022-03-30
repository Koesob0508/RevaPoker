using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpriteGenerator))]
public class SpriteGenerateButton : Editor
{
    public int debugNumber;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SpriteGenerator generator = (SpriteGenerator)target;

        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        if(GUILayout.Button("Generate Sprite"))
        {
            generator.GenerateSprites();
        }

        if(GUILayout.Button("Debug Log"))
        {
            generator.DebugSprites(debugNumber);
        }

        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
    }
}
