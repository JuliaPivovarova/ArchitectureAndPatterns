using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Object_Pool
{
    internal sealed class WorkWithPool
    {
        private Transform _rootPool;
        private string _name;
        private GameObject[] _poolObjects;
        private bool _isUsing;
        private Dictionary<GameObject, bool> _objectStatus;

        public WorkWithPool(Transform rootPool, string name, GameObject[] poolObjects)
        {
            _rootPool = rootPool;
            _name = name;
            _poolObjects = poolObjects;
            _objectStatus = new Dictionary<GameObject, bool>();
            for (int i = 0; i < poolObjects.Length; i++)
            {
                _objectStatus.Add(poolObjects[i], false);
            }
        }

        public GameObject GetFromPool()
        {
            for (int i = 0; i < _poolObjects.Length; i++)
            {
                if (!_objectStatus[_poolObjects[i]])
                {
                    _objectStatus[_poolObjects[i]] = true;
                    _poolObjects[i].SetActive(true);
                    return _poolObjects[i];
                }
            }

            throw new Exception("Pool is not big enough");
            return null;
        }

        public void ReturnToPool(GameObject obj)
        {
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            obj.transform.gameObject.SetActive(false);
            _objectStatus[obj] = false;
            obj.transform.SetParent(_rootPool);
        }
    }
}