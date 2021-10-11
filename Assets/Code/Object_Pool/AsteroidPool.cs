using System.Collections.Generic;
using System.Linq;
using Code.AttachedToObject;
using UnityEngine;

namespace Code.Object_Pool
{
    internal sealed class AsteroidPool: EnemyPool
    {
        private Transform _rootPool;
        private int _capacityPool;
        
        public AsteroidPool(int capacityPool, EnemyType enemyType) : base(capacityPool, enemyType)
        {
            _capacityPool = capacityPool;
            if (!_rootPool)
            {
                _rootPool = new GameObject(NameManager.POOL_ASTEROID).transform;
            }
        }

        public Enemy.Enemy GetEnemy()
        {
            return GetAsteroid(GetListEnemies("Asteroids"));
        }
        
        private Enemy.Enemy GetAsteroid(HashSet<Enemy.Enemy> enemies)
        {
            var enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (enemy == null)
            {
                var laser = Resources.Load<Asteroid>("Enemy/Asteroid");
                for (int i = 0; i < _capacityPool; i++)
                {
                    var instantiate = Object.Instantiate(laser);
                    ReturnToPool(instantiate.transform, _rootPool);
                    enemies.Add(instantiate);
                }

                GetAsteroid(enemies);
            }

            enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            return enemy;
        }

        public Transform GetRootPool()
        {
            return _rootPool;
        }
    }
}