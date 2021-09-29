using UnityEngine;

namespace Code
{
    internal sealed class InstantiateBullet
    {
        private static GameObject _temAmmunition;
        public static GameObject InstBullet(GameObject bullet, Transform barrel)
        {
            _temAmmunition = GameObject.Instantiate(bullet, barrel.position, barrel.rotation);
            return _temAmmunition;
        }
    }
}