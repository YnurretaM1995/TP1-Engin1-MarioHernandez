using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "Menu";
    [SerializeField] private int levelToUnlock=2;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (PlayerPrefs.GetInt("LevelReached", 1) < levelToUnlock)
            {
                PlayerPrefs.SetInt("LevelReached", levelToUnlock);
                PlayerPrefs.Save();
            }
            SceneManager.LoadScene(nextSceneName);
        }
    }
}