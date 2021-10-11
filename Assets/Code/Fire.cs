using Code.Object_Pool;
using UnityEngine;

namespace Code
{
    internal sealed class Fire
    {
        private readonly GameObject _bullet;
        private readonly Transform _barrel;

        public Fire(){}
        
        public Fire(GameObject bullet, Transform barrel)
        {
            _bullet = bullet;
            _barrel = barrel;
        }

        public void SingleFire(float force)
        {
            //var temAmmunition = InstantiateBullet.InstBullet(_bullet, _barrel);
            //temAmmunition.SetActive(true);
            var temAmmunition = PoolsDictionary.GetFromDic("PlayerMissile").GetFromPool();
            temAmmunition.transform.position = _barrel.position;
            temAmmunition.transform.rotation = _barrel.rotation;
            temAmmunition.GetComponent<Rigidbody2D>().AddForce(_barrel.up * force);
            
        }
    }
}