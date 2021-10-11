using System;
using Code.AttachedToObject;
using Code.Object_Pool;
using UnityEngine;

namespace Code
{
    internal abstract class Bullet: MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Asteroid>(out _) && other.gameObject.activeSelf && gameObject.activeSelf)
            {
                PoolsDictionary.GetFromDic("Asteroid").ReturnToPool(other.gameObject);
                if (gameObject.TryGetComponent<EnemyShipMissile>(out _))
                {
                    PoolsDictionary.GetFromDic("EnemyShipMissile").ReturnToPool(gameObject);
                }
                else
                {
                    PoolsDictionary.GetFromDic("PlayerMissile").ReturnToPool(gameObject);
                }
                
            }
        }
    }
}