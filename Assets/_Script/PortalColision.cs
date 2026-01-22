using UnityEngine;
using System.Collections;

public class PortalColision : MonoBehaviour
{
    [SerializeField]private SceneHandler _nextScene;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _delay = .35f;
    [SerializeField] private AudioSource _audioSource;
    
    private bool _isTransitioning = false;
    
    private void Awake()
    {
        if (!_animator)
            _animator = GetComponent<Animator>();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (_isTransitioning) return;

        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(WaitAndChangeScene());
        }
       
    }
    private IEnumerator WaitAndChangeScene()
    {
        _isTransitioning = true;
        AudioManager.instance.PlayPortal(_audioSource);
        
        _animator.SetBool("IsClose", true);
        yield return new WaitForSeconds(_delay);

        _nextScene.NextScene();
    }
}
