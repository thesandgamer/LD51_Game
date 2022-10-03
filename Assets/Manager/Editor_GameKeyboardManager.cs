using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof (Scr_GameKeyboardManager))]

public class Editor_GameKeyboardManager : Editor
{
    public override void OnInspectorGUI()
    {
        Scr_GameKeyboardManager gameKeyboardManager = (Scr_GameKeyboardManager) target;
        DrawDefaultInspector();
        /*
        if (DrawDefaultInspector())
        {
            gameKeyboardManager.ClearKeys();
            gameKeyboardManager.GenerateKeyboard();
        }*/
        GUILayout.Space(20);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Spawn keyboard"))
        {
            if (gameKeyboardManager.inGameKeys.Count <= 0)
            {
                gameKeyboardManager.GenerateKeyboard();
            }
            else
            {
                Debug.LogWarning("Tower already exist");
                EditorUtility.DisplayDialog("Tower construction","Tower already exist"," Ok ");
            }
        }

        if (GUILayout.Button("Remove keys"))
        {
            gameKeyboardManager.ClearKeys();

        }
        GUILayout.EndHorizontal();
    }
}

#endif