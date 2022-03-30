using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerManager))]
public class PlayerManagerButton : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        PlayerManager playerManager = (PlayerManager)target;

        if(GUILayout.Button("Set Card"))
        {
            playerManager.SetCard();
        }

        if(GUILayout.Button("Remove Card"))
        {
            playerManager.RemoveCard();
        }

        if(GUILayout.Button("Set Direction"))
        {
            playerManager.SetDirection();
        }
    }
}
