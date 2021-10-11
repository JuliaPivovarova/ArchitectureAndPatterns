using Code.CodeToSingltoneAndServiceLocator;
using Code.Object_Pool;
using UnityEngine;

namespace Code
{
    internal sealed class Fire
    {
        private readonly GameObject _bullet;
        private readonly Transform _barrel;
        private readonly Sprite _sprite;

        public Fire(){}
        
        public Fire(GameObject bullet, Transform barrel, Sprite sprite)
        {
            _bullet = bullet;
            _barrel = barrel;
            _sprite = sprite;
        }

        public void SingleFire(float force)
        {
            var gameObjectBuilder = new GameObjectBuilder();
            GameObject temAmmunition = gameObjectBuilder.Visual.Sprite(_sprite).Physics.Rigidbody2D(0.0001f)
                .CapsuleCollider2D().PlayerMissileAdd();
            //var temAmmunition = InstantiateBullet.InstBullet(_bullet, _barrel);
            temAmmunition.SetActive(true);
            temAmmunition.GetComponent<CapsuleCollider2D>().isTrigger = true;
            //var temAmmunition = PoolsDictionary.GetFromDic("PlayerMissile").GetFromPool();
            temAmmunition.transform.position = _barrel.position;
            temAmmunition.transform.rotation = _barrel.rotation;
            temAmmunition.GetComponent<Rigidbody2D>().AddForce(_barrel.up * force);
            
        }
    }
}