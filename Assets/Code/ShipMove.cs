using Code.Interface;
using UnityEngine;

namespace Code
{
    internal sealed class ShipMove: IMove
    {
        private readonly IMove _moveImplementation;

        public float Speed => _moveImplementation.Speed;

        public ShipMove(){}
        
        public ShipMove(IMove moveImplementation)
        {
            _moveImplementation = moveImplementation;
        }
        public void Move(float horizontal, float vertical, float deltaTime, Rigidbody2D rigidbody)
        {
            _moveImplementation.Move(horizontal, vertical, deltaTime, rigidbody);
        }

        public void AddAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }
        
        public void RemoveAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }
    }
}