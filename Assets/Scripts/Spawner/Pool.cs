using System;
using System.Collections.Generic;
using UnityEngine;

namespace CyberpunkAwakening.Spawning
{
    public class Pool : MonoBehaviour
    {
        [SerializeField] private PoolObject _prefab;
        [Space(10)] [SerializeField] private Transform _container;
        [SerializeField] private int _minCapacity;
        [SerializeField] private int _maxCapacity;
        [SerializeField] private bool _autoExpand;

        private List<PoolObject> _pool;

        private void OnValidate()
        {
            if (_autoExpand == true)
            {
                _maxCapacity = int.MaxValue;
            }
        }

        private void Start()
        {
            _container.parent = null;
            CreatePool();
        }

        private void CreatePool()
        {
            _pool = new List<PoolObject>(_minCapacity);

            for (int i = 0; i < _minCapacity; i++)
            {
                CreateElement();
            }
        }

        private PoolObject CreateElement(bool isActiveByDefault = false)
        {
            var createdElement = Instantiate(_prefab, _container);
            createdElement.gameObject.SetActive(isActiveByDefault);
            _pool.Add(createdElement);
            return createdElement;
        }


        private bool TryGetElement(out PoolObject element)
        {
            var result = false;
            element = null;

            foreach (var poolObject in _pool)
            {
                if (poolObject.gameObject.activeInHierarchy == false)
                {
                    element = poolObject;
                    element.gameObject.SetActive(true);
                    result = true;
                    break;
                }
            }

            return result;
        }

        public PoolObject GetFreeElement(Vector3 position, Quaternion rotation)
        {
            var element = GetFreeElement(position);
            element.transform.rotation = rotation;
            return element;
        }

        public PoolObject GetFreeElement(Vector3 position)
        {
            var element = GetFreeElement();
            element.transform.position = position;
            return element;
        }

        public PoolObject GetFreeElement()
        {
            PoolObject result;

            if (TryGetElement(out var element))
            {
                result = element;
            }
            else if (_autoExpand == true)
            {
                result = CreateElement(true);
            }
            else if (_pool.Count < _maxCapacity)
            {
                result = CreateElement(true);
            }
            else
            {
                throw new Exception("Pool is over!");
            }

            return result;
        }
    }
}