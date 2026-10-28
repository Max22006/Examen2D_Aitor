using UnityEngine; 
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody2D _rBody;

    private InputAction _moveAction;
    private Vector2 _moveInput;
    [SerializeField] private float _movementSpeed = 10f;

    private Animator _animator;

    private InputAction _jumpAction;
    [SerializeField] private float _jumpHeight = 5f;

    [SerializeField] private Transform _groundSensor;
    [SerializeField] private float _sensorRadius = 0.5f;
    
    void Awake()
    {
        _rBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _moveAction = InputSystem.actions["Move"];
        _jumpAction = InputSystem.actions["Jump"];
    }

    
    void Update()
    {
        _moveInput = _moveAction.ReadValue<Vector2>();

        if(_moveInput.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _animator.SetBool("IsRunning", true);
        }
        else if(_moveInput.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _animator.SetBool("IsRunning", true);
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }

        if(_jumpAction.WasPressedThisFrame() && IsGrounded())
        {
            Jump();
        }
        _animator.SetBool("IsJumping", !IsGrounded());
        
    }
    
    void FixedUpdate()
    {
        _rBody.linearVelocityX = _movementSpeed * _moveInput.x;
    }
    void Jump()
    {
        _rBody.AddForce(Vector2.up * _jumpHeight, ForceMode2D.Impulse);
    }
    bool IsGrounded()
    {
        Collider2D[] colliders2D = Physics2D.OverlapCircleAll(_groundSensor.position, _sensorRadius);

        foreach (Collider2D item in colliders2D)
        {
            if (item.gameObject.layer == 6)
            {
                return true;
            }
        }
        return false;
    }

}
