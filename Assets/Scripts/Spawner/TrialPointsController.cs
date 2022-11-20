using CyberpunkAwakening.Player;
using System.Collections.Generic;

internal class TrialPointsController
{
    private List<TrialPoint> _trialPoints;
    private SpawberController _spawberController;
    private PlayerManager _playerManager;

    public TrialPointsController(List<TrialPoint> trialPoints, PlayerManager playerManager)
    {
        _trialPoints = trialPoints;
        _playerManager = playerManager;
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
        _spawberController = new SpawberController(trialPoint, _playerManager);
    }

    public void Update()
    {
        _spawberController?.Update();
    }
}