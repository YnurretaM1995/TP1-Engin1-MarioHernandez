using System;
using UnityEngine;

public class FloorControl : BaseFloorAction
{
    [SerializeField] private Vector3 _translation;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private FloorFollower _Floor1;
    [SerializeField] private FloorFollower _Floor2;
    
    private void OnCollisionEnter(Collision other)
    {
        FloorCollision();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        FloorCollision();
    }
    
    public void FloorCollision()
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
        FloorMovement();
    }

    private void FloorMovement()
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