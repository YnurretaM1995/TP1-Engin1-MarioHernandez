using UnityEngine;
using System.Collections;

public class LavaControl : MonoBehaviour
{
    [SerializeField]private SceneHandler _reloadScene;
    [SerializeField] private AudioSource _audioSource;
    private float _delay = 1f;
    
    private void OnCollisionEnter(Collision other)
    {
        StartCoroutine(DeathScene());
    }
    
    private IEnumerator DeathScene()
    {
        AudioManager.instance.PlayDeath(_audioSource);
        yield return new WaitForSeconds(_delay);
        
        LevelManager.instance.ReloadCurrentLevel();
       
    }
}
