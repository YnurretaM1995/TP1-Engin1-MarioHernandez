using UnityEngine;
using System.Collections.Generic;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> _steps;

    public void UpdateProgress(int currentLevelIndex)
    {
        for (int i = 0; i < _steps.Count; i++)
        {
            if (i <= currentLevelIndex)
                _steps[i].SetActive(true);
            
            else
                _steps[i].SetActive(false);
        }
    }
}