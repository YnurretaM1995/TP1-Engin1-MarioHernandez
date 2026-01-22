using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public event Action<Vector2> OnMove;
    public event Action OnJump;
    [SerializeField] private PlayerInput _playerInput;

    private void Awake()
    {
        if (!_playerInput)
            _playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _playerInput.actions["Move"].performed += MovePerformed;
        _playerInput.actions["Move"].canceled += MovePerformed;

        _playerInput.actions["Jump"].performed += JumpPerformed;
    }

    private void OnDisable()
    {
        _playerInput.actions["Move"].performed -= MovePerformed;
        _playerInput.actions["Move"].canceled -= MovePerformed;
        
        _playerInput.actions["Jump"].performed -= JumpPerformed;
    }

    void MovePerformed(InputAction.CallbackContext ctx)
    {
        OnMove?.Invoke(ctx.ReadValue<Vector2>());
    }

    void JumpPerformed(InputAction.CallbackContext ctx)
    {
        OnJump?.Invoke();
    }
    
}
