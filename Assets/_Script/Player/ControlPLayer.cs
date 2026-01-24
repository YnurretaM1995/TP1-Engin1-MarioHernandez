using System;
using UnityEngine;

public class ControlPLayer : MonoBehaviour
{
    [SerializeField]private InputHandler _inputHandler;
    [SerializeField]private Rigidbody _rb;
    
    [Header("Move")] 
        [SerializeField] private Vector3 _moveDirection;
        [SerializeField] private float _speed;
    
    [Header("Jump")] 
        [SerializeField] private float _jumpForce;
        [SerializeField] private bool _isGrounded;
        [SerializeField] private float _distanceToGround;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private ForceMode _forceMode; 
    
    [Header("Animation")] 
        [SerializeField] private Animator _animator;
    
    [Header("Sounds")] 
        [SerializeField] private AudioSource _audioSource;

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
        Vector3 targetVelocity = new Vector3(_moveDirection.x * _speed, _rb.linearVelocity.y, 0);
        _rb.linearVelocity = targetVelocity;
        
        if (_moveDirection.x > 0)
            transform.rotation = Quaternion.Euler(0, 90, 0); 
        else if (_moveDirection.x < 0)
            transform.rotation = Quaternion.Euler(0, -90, 0);
 
    }
    
    public  void OnJump()
        {
            if(!_isGrounded) return;
            
            _rb.linearVelocity = new Vector3(_rb.linearVelocity.x, 0f, 0f);
            _rb.AddForce(new Vector3(0f,_jumpForce,0f),_forceMode);
            AudioManager.instance.PlayJump(_audioSource);
         }
        
    public  bool IsGrounded()
        {
            Vector3 origin = transform.position + Vector3.up * 0.1f;
            float totalDistance = _distanceToGround + 0.1f;

            bool grounded = Physics.Raycast(origin, Vector3.down, totalDistance, _groundMask);
            
            Debug.DrawRay(origin, Vector3.down * totalDistance, Color.red);
            _animator.SetBool("IsGrounded", grounded);

            return grounded;
        }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Portal") || other.gameObject.CompareTag("Lava"))
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lava"))
            gameObject.SetActive(false);
    }
}
