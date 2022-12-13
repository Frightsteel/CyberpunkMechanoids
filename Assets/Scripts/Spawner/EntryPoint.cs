using System.Collections.Generic;
using CyberpunkAwakening.Player;
using CyberpunkAwakening.Spawning;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private List<TrialPoint> _trialPoints;
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] private List<PoolObject> _prefabEnemis;
    [SerializeField] private Transform _container;
    [SerializeField] private int _decayTimer = 3;

    private TrialPointsController _trialPointsController;

    void Start()
    {
        _trialPointsController =
            new TrialPointsController(_trialPoints, _playerManager, _prefabEnemis, _container, _decayTimer);
    }

    void Update()
    {
        _trialPointsController.Update();
    }
}
