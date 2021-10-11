using System.Collections.Generic;
using UnityEngine;

namespace Code.Object_Pool
{
    internal class BulletPool
    {
        private readonly Dictionary<string, HashSet<Bullet>> _bulletPool;

        public BulletPool(int capacityPool)
        {
            _bulletPool = new Dictionary<string, HashSet<Bullet>>();
        }
        
        protected HashSet<Bullet> GetListBullets(string type)
        {
            return _bulletPool.ContainsKey(type) ? _bulletPool[type] : _bulletPool[type] = new HashSet<Bullet>();
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