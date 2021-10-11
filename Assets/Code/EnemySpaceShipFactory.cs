using Code.AttachedToObject;
using Code.Interface;
using UnityEngine;

namespace Code
{
    internal sealed class EnemySpaceShipFactory: IEnemyFactory
    {
        public Enemy.Enemy Create(Health hp)
        {
            var enemy = Object.Instantiate(Resources.Load<EnemySpaceShip>("Enemy/EnemySpaceShip"));
            enemy.DependencyInjectHealth(hp);
            return enemy;
        }
    }
}