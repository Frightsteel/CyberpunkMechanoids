using System.Collections;
using System.Collections.Generic;
using CyberpunkAwakening.Player;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private List<TrialPoint> _trialPoints;
    [SerializeField] private PlayerManager _playerManager;

    private TrialPointsController _trialPointsController; 

    void Start()
    {
        _trialPointsController = new TrialPointsController(_trialPoints, _playerManager);
    }
    void Update()
    {
        _trialPointsController.Update();
    }
}
