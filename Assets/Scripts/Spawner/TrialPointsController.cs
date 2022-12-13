using CyberpunkAwakening.Player;
using System.Collections.Generic;
using Controllers;
using CyberpunkAwakening.Spawning;
using UnityEngine;

internal class TrialPointsController : BaseController
{
    private List<TrialPoint> _trialPoints;
    private PlayerManager _playerManager;
    private List<PoolObject> _prefabEnemis;
    private Transform _container;
    private int _decayTimer;

    private PoolController _poolController;
    private SpawberController _spawberController;


    public TrialPointsController(List<TrialPoint> trialPoints, PlayerManager playerManager,
        List<PoolObject> _prefabEnemis, Transform container, int decayTimer)
    {
        _trialPoints = trialPoints;
        _playerManager = playerManager;
        _container = container;
        _decayTimer = decayTimer;
        _poolController = new PoolController(trialPoints, _prefabEnemis, _container);

        Subscribe();
    }

    private void Subscribe()
    {
        foreach (var trialPoint in _trialPoints)
        {
            trialPoint.StartTrialEvent += StartTrial;
        }
    }

    private void Unsubscribe()
    {
        foreach (var trialPoint in _trialPoints)
        {
            trialPoint.StartTrialEvent -= StartTrial;
        }
    }

    private void StartTrial(TrialPoint trialPoint)
    {
        _spawberController = new SpawberController(trialPoint, _playerManager, _poolController, _decayTimer);
    }

    public void Update()
    {
        _spawberController?.Update();
    }

    protected override void OnDispose()
    {
        Unsubscribe();
        _spawberController?.Dispose();
    }
}