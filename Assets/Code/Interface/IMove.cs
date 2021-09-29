using UnityEngine;

namespace Code.Interface
{
    public interface IMove
    {
        float Speed { get; }
        void Move(float horizontal, float vertical, float deltaTime, Rigidbody2D rigidbody);
    }
}