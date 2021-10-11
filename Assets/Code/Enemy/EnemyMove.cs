using UnityEngine;

namespace Code.Enemy
{
    internal sealed class EnemyMove
    {
        private Camera _camera;
        private float _borderMinX;
        private float _borderMaxX;
        private float _borderMinY;
        private float _borderMaxY;
        private Transform _trPlace;
        private Transform _player;

        public EnemyMove(Camera camera, Transform player)
        {
            _camera = camera;
            _player = player;
            PlaceToInstantiateEnemy.Borders(_camera, ref _borderMinX, ref _borderMaxX, ref _borderMinY, ref _borderMaxY);
        }

        public bool BordersTrue(Transform position)
        {
            if (position.position.x > _borderMaxX || position.position.x < _borderMinX ||
                position.position.y > _borderMaxY || position.position.y < _borderMinY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Transform StartMovePlace()
        {
            float placeX = Random.Range(_borderMinX, _borderMaxX);
            _trPlace.position = new Vector3(placeX, _borderMaxY, 0);
            _trPlace.rotation = Quaternion.identity;
            return _trPlace;
        }

        public void StartMove(GameObject obj, float force)
        {
            obj.GetComponent<Rigidbody2D>().AddForce((obj.transform.position - _player.position) * force);
        }
    }
}