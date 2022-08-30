using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private PlayerInput _input;
    private Vector2 _movementInput;

    public bool IsSprint { get; private set; }
    public float VerticalInput { get; private set; }
    public float HorizontalInput { get; private set; }

    private void Awake()
    {
        _input = new PlayerInput();
        _input.CharacterControls.Movement.performed += context => _movementInput = context.ReadValue<Vector2>();
        _input.CharacterControls.Sprint.started += context => IsSprint = context.ReadValueAsButton();
        _input.CharacterControls.Sprint.canceled += context => IsSprint = context.ReadValueAsButton();
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
        //HandleSprintInput();
        //HandleJumpInput
        //HandleShootInput
    }

    private void HandleMovementInput()
    {
        VerticalInput = _movementInput.y;
        HorizontalInput = _movementInput.x;
    }

    private void HandleSprintInput()
    {
    }
}