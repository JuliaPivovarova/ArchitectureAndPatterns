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
            var temAmmunition = InstantiateBullet.InstBullet(_bullet, _barrel);
            temAmmunition.SetActive(true);
            temAmmunition.GetComponent<Rigidbody2D>().AddForce(_barrel.up * force);
        }
    }
}