using UnityEngine;

namespace CyberpunkAwakening.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private LayerMask _colliderLayerMask;
        [SerializeField] private Transform _cursorMark;

        [SerializeField] private float _movementSpeed = 7f;
        [SerializeField] private float _sprintSpeed = 14f;
        [SerializeField] private float _rotationSpeed = 15f;

        private PlayerInputController _input;
        private Rigidbody _rigidbody;
        private float _actualSpeed;
        private Camera _camera;

        private void Awake()
        {
            _input = GetComponent<PlayerInputController>();
            _rigidbody = GetComponent<Rigidbody>();
            _camera = Camera.main;
        }

        public void HandleAllMovement()
        {
            HandleMovement();
            HandleRotation();
        }

        private void HandleMovement()
        {
            var moveDirection =
                transform.TransformDirection(new Vector3(_input.HorizontalInput, 0f, _input.VerticalInput));
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

            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            Quaternion playerRotation =
                Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.fixedDeltaTime);

            transform.rotation = playerRotation;
        }

        private Vector3 GetMouseWorldPosition()
        {
            var result = Vector3.zero;
            var screenPosition = Input.mousePosition;
            var ray = _camera.ScreenPointToRay(screenPosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, _colliderLayerMask))
            {
                result = raycastHit.point;
            }

            _cursorMark.position = result;
            return result;
        }
    }
}