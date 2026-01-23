using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _levelSelectorPanel;

    
    public void OpenLevelSelector()
    {
        _mainMenuPanel.SetActive(false);
        _levelSelectorPanel.SetActive(true);
    }
    
    public void OpenMainMenu()
    {
        _mainMenuPanel.SetActive(true);
        _levelSelectorPanel.SetActive(false);
    }
    
    public void LoadScene(string sceneName)
    {
        LevelManager.ResetLevelIndex();
        SceneManager.LoadScene(sceneName);
    }

}
