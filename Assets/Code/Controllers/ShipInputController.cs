using UnityEngine;

namespace Code.Controllers
{
    internal sealed class ShipInputController
    {
        private ShipMove _shipMoveRotate;
        private GameObject _player;
        private Camera _camera;
        private Rigidbody2D _rigidbody;

        public ShipInputController(ShipMove shipMoveRotate, GameObject player, Camera camera, Rigidbody2D rigidbody)
        {
            _shipMoveRotate = shipMoveRotate;
            _player = player;
            _camera = camera;
            _rigidbody = rigidbody;
        }

        public void Execute()
        {
            _player.GetComponent<Transform>().LookAt(Input.mousePosition - _camera.WorldToScreenPoint(_player.transform.position));
            
            _shipMoveRotate.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime, _rigidbody);
        }
    }
}