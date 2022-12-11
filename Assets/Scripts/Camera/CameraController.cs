using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private GameObject _player;

    [Header("Отдаление камеры")]
    [SerializeField] private float _min = 5;
    [SerializeField] private float _max = 15;
    [SerializeField] private int _speed = 1;

    private Camera _camera;
    private float AxisX;
    private float AxisY;
    private float AxisZ;

    void Start()
    {
        _camera = GetComponent<Camera>();
        AxisX = _player.transform.position.x - _camera.transform.position.x;
        AxisY = _player.transform.position.y - _camera.transform.position.y;
        AxisZ = _player.transform.position.z - _camera.transform.position.z;
    }

    
    void Update()
    {
        Vector3 positionCamera = new Vector3(_player.transform.position.x - AxisX, _player.transform.position.y - AxisY,
            _player.transform.position.z - AxisZ);
        _camera.transform.position = positionCamera;

        if (Input.mouseScrollDelta.y != 0)
        {
            if (_camera.transform.position.y + (-Input.mouseScrollDelta.y * _speed) <= _min)
                return;
            if (_camera.transform.position.y + (-Input.mouseScrollDelta.y * _speed) >= _max)
                return;
            AxisY += Input.mouseScrollDelta.y * _speed;
            AxisZ -= Input.mouseScrollDelta.y * _speed;
            Debug.Log(Input.mouseScrollDelta.y);
        }
    }
}
