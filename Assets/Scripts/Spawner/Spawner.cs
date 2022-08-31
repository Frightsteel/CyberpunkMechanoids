using System;
using System.Collections.Generic;
using CyberpunkAwakening.Player;
using CyberpunkAwakening.Test;
using UniRx;
using UnityEngine;

namespace CyberpunkAwakening.Spawning
{
    [RequireComponent(typeof(Pool))]
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private float _timeToSpawn = 2f;
        [SerializeField] private List<Transform> _points;

        private int _currentSpawnPoint;
        private Pool _pool;
        private IDisposable _disposable;
        private PlayerManager _player;

        private void Awake()
        {
            _pool = GetComponent<Pool>();
            _player = FindObjectOfType<PlayerManager>();
        }

        private void Start()
        {
            StartSpawn();
        }

        private void OnDestroy()
        {
            StopSpawn();
        }

        private void StartSpawn()
        {
            _disposable = Observable.Timer(TimeSpan.FromSeconds(_timeToSpawn))
                .Repeat()
                .Subscribe(_ =>
                {
                    print("Spawn");
                    _currentSpawnPoint %= _points.Count;
                    var point = _points[_currentSpawnPoint++];
                    var enemy = _pool.GetFreeElement(point.position);
                    enemy.GetComponent<EnemyTest>().Init(_player);
                }).AddTo(this);
        }

        private void StopSpawn()
        {
            _disposable?.Dispose();
        }
    }
}