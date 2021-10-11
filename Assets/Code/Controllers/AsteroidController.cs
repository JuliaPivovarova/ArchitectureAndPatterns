using System.Collections;
using Code.Enemy;
using Code.Object_Pool;
using UnityEngine;

namespace Code.Controllers
{
    internal sealed class AsteroidController
    {
        private EnemyMove _enemyMove;
        private float _force;
        private static int _asteroidsExist;

        public AsteroidController(EnemyMove enemyMove, float force)
        {
            _enemyMove = enemyMove;
            _force = force;
            _asteroidsExist = 0;
        }

        public Transform GetPosition(GameObject asteroid)
        {
            asteroid.transform.position = _enemyMove.StartMovePlace().position;
            return asteroid.transform;
        }

        public void AsteroidStart(GameObject asteroid)
        {
            _enemyMove.StartMove(asteroid, _force);
            _asteroidsExist++;
        }
        
        public IEnumerator LifeTime(GameObject asteroid)
        {
            yield return new WaitForSeconds(4f);
            PoolsDictionary.GetFromDic("Asteroid").ReturnToPool(asteroid);
            _asteroidsExist--;
        }

        public static int AsteroidsNumber()
        {
            return _asteroidsExist;
        }
    }
}