using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public void OnRestartButtonClicked()
    {
        if (LevelManager.instance != null)
            LevelManager.instance.ResetToFirstLevel();
    }
}
