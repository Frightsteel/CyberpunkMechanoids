using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask _colliderLayerMask;
    [SerializeField] private Transform _cursorMark; //temp

    [SerializeField] private float _movementSpeed = 7f;
    [SerializeField] private float _sprintSpeed = 14f;
    [SerializeField] private float _rotationSpeed = 15f;

    private PlayerInputController _input;
    
    private Rigidbody _rigidbody;

    private float _actualSpeed;

    private void Awake()
    {
        _input = GetComponent<PlayerInputController>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        Vector3 moveDirection = transform.TransformDirection(new Vector3(_input.HorizontalInput, 0f, _input.VerticalInput));
        moveDirection.Normalize();
        
        _actualSpeed = _input.IsSprint ? _sprintSpeed : _movementSpeed;
        moveDirection *= _actualSpeed;

        Vector3 movementVelocity = moveDirection;
        
        _rigidbody.velocity = movementVelocity;
    }

    private void HandleRotation()
    {
        Vector3 targetPoint = GetMouseWorldPosition();
        targetPoint.y = transform.position.y;
        
        Vector3 targetDirection = (targetPoint - transform.position).normalized;
        //transform.forward = Vector3.Lerp(transform.forward, targetDirection, 1f);

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.fixedDeltaTime);

        transform.rotation = playerRotation;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 result = Vector3.zero;
        Vector3 screenPosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, _colliderLayerMask))
        {
            result = raycastHit.point;
        }

        _cursorMark.position = result;
        return result;
    }
}
