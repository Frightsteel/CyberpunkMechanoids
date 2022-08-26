using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private PlayerInput _input;

    private Vector2 _movementInput;
    
    public float verticalInput { get; private set; }
    public float horizontalInput { get; private set; }

    private void Awake()
    {
        _input = new PlayerInput();
        _input.CharacterControls.Movement.performed += context => _movementInput = context.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        _input.CharacterControls.Enable();
    }

    private void OnDisable()
    {
        _input.CharacterControls.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
        //HandleJumpInput
        //HandleShootInput
    }

    private void HandleMovementInput()
    {
        verticalInput = _movementInput.y;
        horizontalInput = _movementInput.x;
    }
}