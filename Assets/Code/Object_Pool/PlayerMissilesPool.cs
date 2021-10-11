using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.Object_Pool
{
    internal sealed class PlayerMissilesPool: BulletPool
    {
        private int _capacityPool;
        private Transform _rootPool;
        
        public PlayerMissilesPool(int capacityPool) : base(capacityPool)
        {
            _capacityPool = capacityPool;
            _rootPool = new GameObject(NameManager.POOL_MISSILESPLAYER).transform;
        }
        
        public Bullet GetBullet()
        {
            return GetMissile(GetListBullets("PlayerMissiles"));
        }
        
        private Bullet GetMissile(HashSet<Bullet> missiles)
        {
            var bullet = missiles.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (bullet == null)
            {
                var laser = Resources.Load<Bullet>("Bullet/PlayerMissile");
                for (int i = 0; i < _capacityPool; i++)
                {
                    var instantiate = Object.Instantiate(laser);
                    ReturnToPool(instantiate.transform, _rootPool);
                    missiles.Add(instantiate);
                }

                GetMissile(missiles);
            }

            bullet = missiles.FirstOrDefault(a => !a.gameObject.activeSelf);
            return bullet;
        }
        
        public Transform GetRootPool()
        {
            return _rootPool;
        }
    }
}