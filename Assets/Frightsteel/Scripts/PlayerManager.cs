using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerInputController _input;
    private PlayerMovement _movement;

    private void Awake()
    {
        _input = GetComponent<PlayerInputController>();
        _movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        _input.HandleAllInputs();
    }

    private void FixedUpdate()
    {
        _movement.HandleAllMovement();
    }
}
