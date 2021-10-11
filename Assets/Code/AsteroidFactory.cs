using Code.AttachedToObject;
using UnityEngine;
using Code.Interface;

namespace Code
{
    internal sealed class AsteroidFactory: IEnemyFactory
    {
        public Enemy.Enemy Create(Health hp)
        {
            var enemy = Object.Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));
            enemy.DependencyInjectHealth(hp);
            return enemy;
        }
    }
}