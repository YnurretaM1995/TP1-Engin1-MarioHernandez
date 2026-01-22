
using UnityEngine;

public class FloorControl : MonoBehaviour
{
    [SerializeField] private Vector3 _Translation;
    [SerializeField] private AudioSource _audioSource;
    private bool _Touch=false;
    private void OnCollisionEnter(Collision other)
   {
       if (!_Touch)
       {
           transform.Translate(_Translation);
           AudioManager.instance.PlayFloor(_audioSource);
           _Touch = true;
       }
       
   }
    
   
}
