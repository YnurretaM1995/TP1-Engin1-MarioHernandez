using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
   public void ReloadScene()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

   public void NextScene()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
   }
}
