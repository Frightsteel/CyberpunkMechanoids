using CyberpunkAwakening.Player;
using CyberpunkAwakening.Spawning;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

internal class SpawberController
{
    private PlayerManager _playerManager;

    private PoolObject _prefabEnemi1;
    private int _enemies1Count = 5;
    private PoolObject _prefabEnemi2;
    private int _enemies2Count = 5;
    private float _timeToSpawn = 2f;
    private List<Transform> _points;
    private int _timeToStart = 3;
    private TMP_Text _interactionsText;
    private int _decayTimer = 3;
    private GameObject _door;
    private Transform _container;

    private List<PoolObject> _pool;
    private Spawner _spawner;

    private List<PoolObject> _pools;

    private bool isSpawn = false;

    private int i = 0;
    private float time = 0;

    public SpawberController(TrialPoint trialPoint, PlayerManager playerManager)
    {
        _prefabEnemi1 = trialPoint.PrefabEnemi1;
        _enemies1Count = trialPoint.Enemies1Count;
        _prefabEnemi2 = trialPoint.PrefabEnemi2;
        _enemies2Count = trialPoint.Enemies2Count;
        _timeToSpawn = trialPoint.TimeToSpawn;
        _points = trialPoint.Points;
        _timeToStart = trialPoint.TimeToStart;
        _interactionsText = trialPoint.InteractionsText;
        _decayTimer = trialPoint.DecayTimer;
        _door = trialPoint.Door;
        _container = trialPoint.Container;
        _playerManager = playerManager;

        //_pool = new Pool(_prefabEnemi1, _enemies1Count, _container, _prefabEnemi2, _enemies2Count);
        //_spawner = new Spawner(_pool, _playerManager, _timeToSpawn , _points);
        //_spawner.Start();
        CreatePool();
        _pools = new List<PoolObject>();
        isSpawn = true;
        //StartSpawner();
    }

    public void Update()
    {
        if (isSpawn)
        {
            if (_pools.Count != _enemies1Count + _enemies2Count)
            {
                if (time <= 0)
                {
                    time = _timeToSpawn;
                    _pool[i].gameObject.SetActive(true);
                    _pools.Add(_pool[i]);
                    i++;
                }
                else time -= Time.deltaTime;
            }
            else
            {
                isSpawn = false;
            }
        }
    }

    private void StartSpawner()
    {
        var time = _timeToSpawn;
        var i = 0;
        while (_pools.Count != _enemies1Count + _enemies2Count)
        {
            if (time <= 0)
            {
                time = _timeToSpawn;
                _pool[i].gameObject.SetActive(true);
                _pools.Add(_pool[i]);
                i++;
            }
            else time -= Time.deltaTime;
        }
        
    }

    private PoolObject CreateElement(PoolObject prefab, bool isActiveByDefault = false)
    {
        var createdElement = Object.Instantiate(prefab, _container);
        createdElement.gameObject.SetActive(false);
        return createdElement;
    }

    private void CreatePool()
    {
        _pool = new List<PoolObject>();

        for (int i = 0; i < _enemies1Count; i++)
        {
            _pool.Add(CreateElement(_prefabEnemi1));
        }
        for (int i = 0; i < _enemies2Count; i++)
        {
            _pool.Add(CreateElement(_prefabEnemi2));
        }
    }
}