using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _levelSelectorPanel;
    
    [Header("Level Progress")]
    [SerializeField] private Button[] _levelButtons;

    void Start()
    {
        CheckLevelProgress();
    }

    private void CheckLevelProgress()
    {
        int levelReached = PlayerPrefs.GetInt("LevelReached", 1);

        for (int i = 0; i < _levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                _levelButtons[i].interactable = false;
                
                var colors = _levelButtons[i].colors;
                colors.disabledColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
                _levelButtons[i].colors = colors;
            }
            else
                _levelButtons[i].interactable = true;
            
        }
    }
  
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

    public void ResetAllProgress()
    {
        PlayerPrefs.DeleteKey("LevelReached");
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        CheckLevelProgress();
    }
}
