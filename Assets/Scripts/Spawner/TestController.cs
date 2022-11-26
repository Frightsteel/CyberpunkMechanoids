using CyberpunkAwakening.Spawning;
using System.Collections.Generic;
using System.Linq;
using Controllers;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UniRx;

internal class TestController : BaseController
{
    private List<PoolObject> _poolObjects;
    private TMP_Text _interactionsText;
    private GameObject _door;

    private int _count;

    private float _time = 3;
    private bool IsTime = false;

    public TestController(List<PoolObject> poolObjects, TMP_Text interactionsText, GameObject door, int decayTimer)
    {
        _poolObjects = poolObjects;
        _interactionsText = interactionsText;
        _count = _poolObjects.Count;
        _door = door;
        _time = decayTimer;
    }


    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            foreach (var ob in _poolObjects.Where(ob => ob.gameObject.activeSelf == true))
            {
                ob.gameObject.SetActive(false);
                _count--;
                return;
            }
        }

        if (_count == 0)
        {
            if (IsTest == false)
                TestPassed();
            _door.SetActive(true);
        }

        if (IsTime)
        {
            if (_time <= 0)
            {
                _interactionsText.gameObject.SetActive(false);
                IsTime = false;
            }
            else _time -= Time.deltaTime;
        }
    }

    private bool IsTest = false;

    private void TestPassed()
    {
        _interactionsText.gameObject.SetActive(true);
        _interactionsText.text = "Испытание пройдено";
        IsTest = true;
        IsTime = true;
    }
}