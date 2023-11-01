using UnityEditor;
using UnityEngine;

public class TutorialEditor : EditorWindow
{
    // Ctrl + Shift + d (HOTKEY)
    [MenuItem("Tools/Create Tutorial Data %#d")]
    public static void ShowWindow()
    {
        GetWindow<TutorialEditor>("Create Tutorial Data");
    }
    private void OnGUI()
    {
        if(GUILayout.Button("Create Tutorial Data"))
        {
            CreateTutorialData();
        }
    }
    void CreateTutorialData()
    {
        TutorialData tutorialData = CreateInstance<TutorialData>();
        string path = AssetDatabase.GenerateUniqueAssetPath("Assets/Resources/Scriptable/Tutorial/Tutorial.asset");
        AssetDatabase.CreateAsset(tutorialData, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = tutorialData;
    }
}
