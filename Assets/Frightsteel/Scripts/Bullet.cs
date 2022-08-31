using CyberpunkAwakening.Spawning;
using UnityEngine;

namespace CyberpunkAwakening.Player
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private PoolObject _poolObject;
        [SerializeField] private float _speed = 20f;

        private const float TimeToHide = 4f;

        private void Start()
        {
            Invoke(nameof(_poolObject.ReturnToPool), TimeToHide);
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = transform.forward * (_speed * Time.fixedDeltaTime);
        }
    }
}