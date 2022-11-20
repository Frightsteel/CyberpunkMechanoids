using CyberpunkAwakening.Spawning;
using UnityEngine;

namespace CyberpunkAwakening.Player
{
    [RequireComponent(typeof(PlayerInputController))]
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] private float _timeToShoot = 0.3f;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private PoolObject _prefab;

        private PlayerInputController _input;
        private Pool _pool;
        private float _timer;

        private void Awake()
        {
            _pool = new Pool(_prefab, 100, _spawnPoint);
            _input = GetComponent<PlayerInputController>();
        }

        private void Shoot()
        {
            _pool.GetFreeElement(_spawnPoint.position, transform.rotation);
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_input.IsShoot && _timer > _timeToShoot)
            {
                Shoot();
                _timer = 0f;
            }
        }
    }
}