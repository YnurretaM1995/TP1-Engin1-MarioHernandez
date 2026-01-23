using System;
using UnityEngine;

public abstract class BaseFloorAction : MonoBehaviour
{
    [SerializeField] protected float _speed;
    protected bool _isActive = false;
    
    [SerializeField] protected float _limit;
    protected Vector3 _initialPosition;
    protected Vector3 _initialScale;
    
    public void SetSpeed(float newSpeed) => _speed = newSpeed;
    public virtual void StartAction() => _isActive = true;

    protected void Start()
    {
            _initialPosition = transform.position;
            _initialScale = transform.localScale;
    }

    public virtual void StopAction()
    {
        _isActive = false;
        this.enabled = false;
    }
    protected abstract void Update(); 
}
