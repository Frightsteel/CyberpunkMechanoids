using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CyberpunkAwakening.Spawning
{
    public class Pool/* : MonoBehaviour*/
    {
        private PoolObject _prefabEnemi1;
        private int _enemies1Count;
        private PoolObject _prefabEnemi2;
        private int _enemies2Count;
        private Transform _container;

        private int _minCapacity;
        private int _maxCapacity;
        private bool _autoExpand;

        private List<PoolObject> _pool;

        public Pool(PoolObject prefabEnemi1, int enemies1Count, Transform container, PoolObject prefabEnemi2 = null, int enemies2Count = 0,  bool autoExpand = false)
        {
            _prefabEnemi1 = prefabEnemi1;
            _enemies1Count = enemies1Count;
            _prefabEnemi2 = prefabEnemi2;
            _enemies2Count = enemies2Count;
            _container = container;
            _minCapacity = enemies1Count + enemies2Count;
            _maxCapacity = _minCapacity*2;
            _autoExpand = autoExpand;

            _container.parent = null;
            CreatePool();
        }

        private void OnValidate()
        {
            if (_autoExpand == true)
            {
                _maxCapacity = int.MaxValue;
            }
        }

        public void Start()
        {
            _container.parent = null;
            CreatePool();
        }

        private void CreatePool()
        {
            _pool = new List<PoolObject>(_minCapacity);

            for (int i = 0; i < _enemies1Count; i++)
            {
                CreateElement(_prefabEnemi1);
            }
            for (int i = 0; i < _enemies2Count; i++)
            {
                CreateElement(_prefabEnemi2);
            }
        }

        private PoolObject CreateElement(PoolObject prefab, bool isActiveByDefault = false)
        {
            var createdElement = Object.Instantiate(prefab, _container);
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
            //else if (_autoExpand == true)
            //{
            //    result = CreateElement(true);
            //}
            //else if (_pool.Count == _maxCapacity)
            //{
            //    return null;
            //}
            else
            {
                throw new Exception("Pool is over!");
            }

            return result;
        }
    }
}