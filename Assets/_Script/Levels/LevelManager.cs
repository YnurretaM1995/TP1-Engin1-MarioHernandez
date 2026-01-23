using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] private List<GameObject> _levels;
    [SerializeField] private Transform _player;
    [SerializeField] private ProgressBarUI _progressBar;
    private Vector3 _spawnPosition = new Vector3(-10f, 1.01f, 0f);
    
    private static int _currentLevelIndex = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ResetPlayerPosition();
        ShowLevel(_currentLevelIndex);
        
        if (_progressBar != null)
            _progressBar.UpdateProgress(_currentLevelIndex);
        
    }

    public void NextLevel()
    {
        if (_currentLevelIndex < _levels.Count - 1)
        {
            _currentLevelIndex++;
            ReloadCurrentLevel();
        }
    }

    public void ReloadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ResetPlayerPosition()
    {
        if (_player != null)
        { 
            _player.position = _spawnPosition;
            Rigidbody rb = _player.GetComponent<Rigidbody>();
            
            if (rb != null)
            { 
                rb.linearVelocity = Vector3.zero; 
                rb.angularVelocity = Vector3.zero;
            }
        }
    }

    private void ShowLevel(int index)
    {
        for (int i = 0; i < _levels.Count; i++)
        {
            _levels[i].SetActive(i == index);
        }
    }
    
    public void ResetToFirstLevel()
        {
            _currentLevelIndex = 0;
            ReloadCurrentLevel();
        }
    public static void ResetLevelIndex()
    {
        _currentLevelIndex = 0;
    }
}