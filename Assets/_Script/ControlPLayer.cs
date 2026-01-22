using System;
using UnityEngine;

public class ControlPLayer : MonoBehaviour
{
    [SerializeField]private InputHandler _inputHandler;
    [SerializeField]private Rigidbody _rb;
    
    [Header("Move")] 
        [SerializeField] private Vector3 _moveDirection;
        [SerializeField] private float _speed=5.0f;
    
    [Header("Jump")] 
        [SerializeField] private float _jumpForce;
        [SerializeField] private bool _isGrounded;
        [SerializeField] private float _distanceToGround;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private ForceMode _forceMode;
    
    [Header("Animation")] 
        [SerializeField] private Animator _animator;

    private void Awake()
    {
        if (!_inputHandler)
            _inputHandler = GetComponent<InputHandler>();
        if (!_rb)
            _rb = GetComponent<Rigidbody>();
        if (!_animator)
            _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        MoveFixed();
    }

    private void Update()
    {
        _isGrounded = IsGrounded();
        
    }

    private void OnEnable()
    {
        _inputHandler.OnMove += Moved;
        _inputHandler.OnJump += OnJump;
    }

    private void OnDisable()
    {
        _inputHandler.OnMove -= Moved;
        _inputHandler.OnJump -= OnJump;
    }

    public void Moved(Vector2 obj)
    {
        _moveDirection = new Vector3(obj.x, 0.0f, 0.0f);
        _animator.SetFloat("Speed", Math.Abs(_moveDirection.x));
    }

    private void MoveFixed()
    {
        
        if (_moveDirection.magnitude > 0)
        {
            _rb.AddForce(_moveDirection * _speed, ForceMode.Force);
            
            Vector3 horizontalVel = new Vector3(_rb.linearVelocity.x, 0, _rb.linearVelocity.z);
            if (horizontalVel.magnitude > _speed)
            {
                Vector3 limitedVel = horizontalVel.normalized * _speed;
                _rb.linearVelocity = new Vector3(limitedVel.x, _rb.linearVelocity.y, limitedVel.z);
            }
        }
        else
            _rb.linearVelocity = new Vector3(0, _rb.linearVelocity.y, 0);
        
        if (_moveDirection.x > 0)
            transform.rotation = Quaternion.Euler(0, 90, 0); 
        
        else if (_moveDirection.x < 0)
            transform.rotation = Quaternion.Euler(0, -90, 0);
 
    }
    
    public  void OnJump()
        {
           
            if(!_isGrounded)
                return;
            _rb.AddForce(new Vector3(0f,_jumpForce,0f),_forceMode);
       }
        
    public  bool IsGrounded()
        {
            Ray ray = new Ray(transform.position, Vector3.down);
            Debug.DrawRay(ray.origin, ray.direction*_distanceToGround, Color.red);
            _animator.SetBool("IsGrounded", _isGrounded);
    
            if (Physics.Raycast(ray, _distanceToGround, _groundMask))
                return true;
            
            return false;
        }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Portal"))
            gameObject.SetActive(false);
 
    }
}
