using UnityEngine;

namespace Code.Controllers
{
    internal sealed class InputController
    {
        private ShipMove _shipMove;
        private Fire _fire;
        private float _force;

        public InputController(ShipMove shipMove, Fire fire, float force)
        {
            _shipMove = shipMove;
            _fire = fire;
            _force = force;
        }

        public void Execute()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _shipMove.AddAcceleration();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _shipMove.RemoveAcceleration();
            }
            
            if (Input.GetButtonDown("Fire1"))
            {
                _fire.SingleFire(_force);
            }
        }
    }
}