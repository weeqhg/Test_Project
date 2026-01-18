using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _moveSpeed = 5f;
    private InputSystem_Actions _inputActions;
    private InputAction _moveAction;
    private InputAction _jumpAction;
    private CharacterController _controller;
    private AnimationController _animation;
    private Vector3 _velocity;
    private const float GRAVITY = -9.81f;
    private float _currentSpeed;

    private bool _isGrounded;
    private void Start()
    {
        _inputActions = new InputSystem_Actions();
        _moveAction = _inputActions.Player.Move;
        _jumpAction = _inputActions.Player.Jump;
        _inputActions.Enable();
        _controller = GetComponent<CharacterController>();
        _animation = GetComponentInChildren<AnimationController>();

        _currentSpeed = _moveSpeed;
    }

    private void Update()
    {
        Vector2 move = _moveAction.ReadValue<Vector2>();
        _isGrounded = _controller.isGrounded;

        if (move.magnitude > 0.1f)
        {
            Vector3 moveDirection = new Vector3(move.x, 0, move.y);
            _currentSpeed = _moveSpeed;
            _controller.Move(moveDirection * _moveSpeed * Time.deltaTime);
        }
        else
        {
            _currentSpeed = 0;
        }

        if (_jumpAction.triggered && _isGrounded)
        {
            _velocity.y = _jumpForce;
            _animation.HadleJump();
        }

        _animation.AnimatorState(_isGrounded, _currentSpeed);
        _velocity.y += GRAVITY * Time.deltaTime;
        _controller.Move(new Vector3(0, _velocity.y, 0) * Time.deltaTime);
    }

    private void OnDestroy()
    {
        if (_inputActions != null) _inputActions.Disable();
        _inputActions = null;
        _moveAction = null;
        _jumpAction = null;
    }
}
