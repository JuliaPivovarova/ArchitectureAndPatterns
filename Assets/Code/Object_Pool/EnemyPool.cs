using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Object_Pool
{
    internal class EnemyPool
    {
        private readonly Dictionary<string, HashSet<Enemy.Enemy>> _enemyPool;
        private readonly int _capacityPool;
        private Transform _rootPool;
        private EnemyType _enemyType;
        

        public EnemyPool(int capacityPool, EnemyType enemyType)
        {
            _enemyPool = new Dictionary<string, HashSet<Enemy.Enemy>>();
            _capacityPool = capacityPool;
            _enemyType = enemyType;
        }

        protected HashSet<Enemy.Enemy> GetListEnemies(string type)
        {
            return _enemyPool.ContainsKey(type) ? _enemyPool[type] : _enemyPool[type] = new HashSet<Enemy.Enemy>();
        }

        protected void ReturnToPool(Transform transform, Transform rootPool)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(rootPool);
        }

        public void RemovePool(Transform rootPool)
        {
            Object.Destroy(rootPool.gameObject);
        }
    }
}