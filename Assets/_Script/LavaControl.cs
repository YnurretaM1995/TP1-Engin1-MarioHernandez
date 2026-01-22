using UnityEngine;

public class LavaControl : MonoBehaviour
{
    [SerializeField]private SceneHandler _reloadScene;
    private void OnCollisionEnter(Collision other)
    {
        _reloadScene.ReloadScene();
    }
}
