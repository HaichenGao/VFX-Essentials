using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[InitializeOnLoad]
public class StatePrompt : EditorWindow
{
    static bool showdialogwindow = true;
    static StatePrompt dialogwindow;
    static string prefkey;

    static StatePrompt()
    {
        EditorApplication.update += Update;
    }
    static void Update()
    {
        var datapath = Application.dataPath;
        var strval = datapath.Split("/"[0]);
        prefkey = strval[strval.Length - 2];

        showdialogwindow = (!EditorPrefs.HasKey(prefkey));
        if (showdialogwindow)
        {
            dialogwindow = GetWindow<StatePrompt>(true);
            dialogwindow.minSize = new Vector2(350, 380);
        }
        EditorApplication.update -= Update;
    }

    public void OnGUI()
    {
        var rect = GUILayoutUtility.GetRect(position.width - 10, 100, GUI.skin.box);

        Texture2D ilranchlogo = AssetDatabase.LoadAssetAtPath<Texture2D>(
            Path.GetDirectoryName(AssetDatabase.GetAssetPath(MonoScript.FromScriptableObject(this))) + "/LogoDialog.png");
        if (ilranchlogo != null)
        {
            GUI.DrawTexture(rect, ilranchlogo, ScaleMode.ScaleToFit);
        }

        GUI.backgroundColor = Color.white;
        EditorGUILayout.HelpBox("Prompt for Beginners:", MessageType.Info, true);
        GUI.backgroundColor = Color.clear;
        EditorGUILayout.HelpBox("This package uses HDRP pipeline as default (out of the box). If you need Universal or built-in pipeline then:", MessageType.None);
        EditorGUILayout.HelpBox("1. For Universal pipeline use prefabs from '_Universal pipeline' folder", MessageType.None);
        EditorGUILayout.HelpBox("2. For built-in pipeline use prefabs from '_Built-in pipeline' folder", MessageType.None);

        GUILayout.FlexibleSpace();
        GUI.backgroundColor = Color.cyan;
        if (GUILayout.Button("Close Prompt"))
        {
            EditorPrefs.SetBool(prefkey, true);
            Close();
        }
    }
}
