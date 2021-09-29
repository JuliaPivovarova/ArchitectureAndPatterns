using Code.Interface;
using UnityEngine;

namespace Code
{
    internal class MoveTransform : IMove
    {
        private readonly Transform _transform;
        private Vector3 _movement;
    
        public float Speed { get; protected set; }

        public MoveTransform(Transform transform, float speed)
        {
            _transform = transform;
            Speed = speed;
        }
        public void Move(float horizontal, float vertical, float deltaTime, Rigidbody2D rigidbody)
        {
            var speed = deltaTime * Speed;
            _movement = new Vector3(horizontal, vertical, 0.0f);
            rigidbody.AddForce(Speed * _movement);
        }
    }
}
