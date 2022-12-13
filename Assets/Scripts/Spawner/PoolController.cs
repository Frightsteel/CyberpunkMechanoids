using Controllers;
using System.Collections.Generic;
using System.Linq;
using CyberpunkAwakening.Spawning;
using UnityEngine;

internal class PoolController : BaseController
{
    private List<TrialPoint> _trialPoint;
    private List<PoolObject> _prefabEnemis;
    private Transform _container;

    private List<PoolObject> _poolEnemies1;
    private List<PoolObject> _poolEnemies2;
    private List<PoolObject> _poolEnemies3;

    public List<PoolObject> PoolEnemies1 => _poolEnemies1;
    public List<PoolObject> PoolEnemies2 => _poolEnemies2;
    public List<PoolObject> PoolEnemies3 => _poolEnemies3;


    public PoolController(List<TrialPoint> trialPoint, List<PoolObject> prefabEnemis, Transform container)
    {
        _trialPoint = trialPoint;
        _prefabEnemis = prefabEnemis;
        _container = container;

        CreatePool();
    }

    private void CreatePool()
    {
        CreatePoolEnemies1();
        CreatePoolEnemies2();
        CreatePoolEnemies3();
    }

    private void CreatePoolEnemies1()
    {
        _poolEnemies1 = new List<PoolObject>();

        var count = _trialPoint.Max(x => x.Enemies1Count);

        for (int i = 0; i < count; i++)
        {
            _poolEnemies1.Add(CreateElement(_prefabEnemis[0]));
        }
    }

    private void CreatePoolEnemies2()
    {
        _poolEnemies2 = new List<PoolObject>();

        var count = _trialPoint.Max(x => x.Enemies2Count);

        for (int i = 0; i < count; i++)
        {
            _poolEnemies2.Add(CreateElement(_prefabEnemis[1]));
        }
    }

    private void CreatePoolEnemies3()
    {
        _poolEnemies3 = new List<PoolObject>();

        var count = _trialPoint.Max(x => x.Enemies3Count);

        for (int i = 0; i < count; i++)
        {
            _poolEnemies3.Add(CreateElement(_prefabEnemis[2]));
        }
    }
    private PoolObject CreateElement(PoolObject prefab, bool isActiveByDefault = false)
    {
        var createdElement = Object.Instantiate(prefab, _container);
        createdElement.gameObject.SetActive(false);
        return createdElement;
    }
}