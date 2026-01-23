using System;
using UnityEngine;

public class FloorControl : BaseFloorAction
{
    [SerializeField] private Vector3 _translation;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private FloorScaleFollower _Floor1;
    [SerializeField] private FloorScaleFollower _Floor2;
    
    private void OnCollisionEnter(Collision other)
    {
        if (!_isActive)
        {
            if (AudioManager.instance != null)
                AudioManager.instance.PlayFloor(_audioSource);

            StartAction();

            if (_Floor1 != null) 
                _Floor1.StartAction();
            
            if (_Floor2 != null) 
                _Floor2.StartAction();
        }
    }
    
    protected override void Update()
    {
        if (_isActive)
        {
            float distance = Vector3.Distance(_initialPosition, transform.position);
            float progress = Mathf.Clamp01(distance / _limit);
            
             if (distance < _limit)
             {
                 transform.Translate(_translation * _speed * Time.deltaTime);

                 if (_Floor1 != null)
                     _Floor1.UpdateScaleProgress(progress);
                 if (_Floor2 != null)
                     _Floor2.UpdateScaleProgress(progress);
             }
             
             else
                 StopAction();
             
        }
    }
}