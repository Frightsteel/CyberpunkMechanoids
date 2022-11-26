using CyberpunkAwakening.Player;
using CyberpunkAwakening.Spawning;
using System.Collections.Generic;
using Controllers;
using TMPro;
using UnityEngine;

internal class SpawberController : BaseController
{
    private PlayerManager _playerManager;
    private PoolController _poolController;
    private int _decayTimer;
    private int _enemies1Count;
    private int _enemies2Count;
    private int _enemies3Count;
    private float _timeToSpawn = 2f;
    private List<Transform> _points;
    private int _timeToStart = 3;
    private TMP_Text _interactionsText;
    private GameObject _door;
    
    private List<PoolObject> _pools;

    private bool isSpawn = false;

    private int _spawnEnaemiCount1 = 0;
    private int _spawnEnaemiCount2 = 0;
    private int _spawnEnaemiCount3 = 0;
    private float time = 0;

    private int j = 0;

    private TestController _testController;


    public SpawberController(TrialPoint trialPoint, PlayerManager playerManager, PoolController poolController, int decayTimer)
    {
        _enemies1Count = trialPoint.Enemies1Count;
        _enemies2Count = trialPoint.Enemies2Count;
        _enemies3Count = trialPoint.Enemies3Count;
        _timeToSpawn = trialPoint.TimeToSpawn;
        _points = trialPoint.Points;
        _timeToStart = trialPoint.TimeToStart;
        _interactionsText = trialPoint.InteractionsText;
        _door = trialPoint.Door;
        _playerManager = playerManager;
        _poolController = poolController;
        
        _decayTimer = decayTimer;

        isSpawn = true;

        _testController = new TestController(TestPool(), _interactionsText, _door, _decayTimer);


    }

    #region Test

    private List<PoolObject> TestPool()
    {
        _pools = new List<PoolObject>();

        for (int i = 0; i < _enemies1Count; i++)
        {
            _pools.Add(_poolController.PoolEnemies1[i]);
        }
        for (int i = 0; i < _enemies2Count; i++)
        {
            _pools.Add(_poolController.PoolEnemies2[i]);
        }
        for (int i = 0; i < _enemies3Count; i++)
        {
            _pools.Add(_poolController.PoolEnemies3[i]);
        }

        return _pools;
    }

    #endregion
    public void Update()
    {
        _testController?.Update();
        if (isSpawn)
        {
            if (_spawnEnaemiCount1 != _enemies1Count)
            {
                if (time <= 0)
                {
                    time = _timeToSpawn;
                    Spawn(_poolController.PoolEnemies1[_spawnEnaemiCount1].gameObject);
                    _spawnEnaemiCount1++;
                }
                else time -= Time.deltaTime;
            }
            else if (_spawnEnaemiCount2 != _enemies2Count)
            {
                if (time <= 0)
                {
                    time = _timeToSpawn;
                    Spawn(_poolController.PoolEnemies2[_spawnEnaemiCount2].gameObject);
                    _spawnEnaemiCount2++;
                }
                else time -= Time.deltaTime;
            }
            else if (_spawnEnaemiCount3 != _enemies3Count)
            {
                if (time <= 0)
                {
                    time = _timeToSpawn;
                    Spawn(_poolController.PoolEnemies3[_spawnEnaemiCount3].gameObject);
                    _spawnEnaemiCount3++;
                }
                else time -= Time.deltaTime;
            }
            else
            {
                isSpawn = false;
            }
        }
    }

    private void Spawn(GameObject enaemi)
    {
        var rand = new System.Random();
        enaemi.transform.position = _points[rand.Next(0, _points.Count)].position;
        enaemi.SetActive(true);
    }

    protected override void OnDispose()
    {
        _testController?.Dispose();
    }
}