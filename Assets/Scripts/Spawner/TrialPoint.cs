using System;
using System.Collections;
using System.Collections.Generic;
using CyberpunkAwakening.Spawning;
using TMPro;
using UnityEngine;

public class TrialPoint : MonoBehaviour
{
    [Header("Настройки спауна")] [SerializeField]
    private int _enemies1Count = 5;

    [SerializeField] private int _enemies2Count = 5;
    [SerializeField] private int _enemies3Count = 5;
    [Space(50)] [SerializeField] private float _timeToSpawn = 2f;
    [SerializeField] private List<Transform> _points;
    [SerializeField] private int _timeToStart = 3;
    [Header("UI")] [SerializeField] private TMP_Text _interactionsText;
    [SerializeField] private int _decayTimer = 3;
    [Header("Дверь")] [SerializeField] private GameObject _door;


    public int Enemies1Count => _enemies1Count;
    public int Enemies2Count => _enemies2Count;
    public int Enemies3Count => _enemies3Count;
    public float TimeToSpawn => _timeToSpawn;
    public List<Transform> Points => _points;
    public int TimeToStart => _timeToStart;
    public TMP_Text InteractionsText => _interactionsText;
    public int DecayTimer => _decayTimer;
    public GameObject Door => _door;

    public Action<TrialPoint> StartTrialEvent;

    private const string Start = "Нажмити Е для начала испытания";
    private const string TrialHasBegun = "Испытание началось";

    private bool _isTrial = false;
    private bool _isCoverageArea = false;

    private void Update()
    {
        if (_isCoverageArea)
            if (Input.GetKeyUp(KeyCode.E))
            {
                _isTrial = true;
                StartCoroutine(StartTrial());
            }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isTrial)
        {
            _interactionsText.gameObject.SetActive(true);
            _interactionsText.text = Start;
            _isCoverageArea = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (!_isTrial)
            _interactionsText.gameObject.SetActive(false);
        _isCoverageArea = false;
    }

    private IEnumerator StartTrial()
    {
        float сountdown = 1;
        for (int i = 0; i < _timeToStart; i++)
        {
            _interactionsText.text = сountdown.ToString();
            сountdown++;
            yield return new WaitForSeconds(1f);
        }

        _interactionsText.text = TrialHasBegun;
        if (StartTrialEvent != null) StartTrialEvent.Invoke(this);
        StartCoroutine(DecayTimers());
        StopCoroutine(StartTrial());
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator DecayTimers()
    {
        yield return new WaitForSeconds(_decayTimer);
        _interactionsText.gameObject.SetActive(false);
        StopCoroutine(DecayTimers());
    }
}
