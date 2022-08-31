using CyberpunkAwakening.Player;
using CyberpunkAwakening.Spawning;
using UnityEngine;

namespace CyberpunkAwakening.Test
{
    [RequireComponent(typeof(PoolObject))]
    public class EnemyTest : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;

        private PoolObject _poolObject;
        private PlayerManager _player;

        private void Awake()
        {
            _poolObject = GetComponent<PoolObject>();
        }

        private void Update()
        {
            if (_player != null)
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    _player.transform.position,
                    _speed * Time.deltaTime
                );
        }

        private void OnDestroy()
        {
            _poolObject.ReturnToPool();
        }

        public void Init(PlayerManager player)
        {
            _player = player;
        }
    }
}