using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public class ForceMenuStart
{
    static ForceMenuStart()
    {
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }

    private static void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingEditMode)
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        
        if (state == PlayModeStateChange.EnteredPlayMode)
            if (EditorSceneManager.GetActiveScene().name != "Menu")
                EditorSceneManager.LoadScene("Menu");
    }
}