using UnityEngine;

namespace ZooWorld
{
    public class LinearMovement : IMovement
    {
        private readonly Rigidbody _rigidbody;
        private readonly float _speed;

        private float _elapsedTime;

        public LinearMovement(Rigidbody rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            _speed = speed;
        }
        
        public void ProcessMovement(Vector3 direction, float deltaTime)
        {
            _rigidbody.MovePosition(_rigidbody.position + direction * _speed * deltaTime);
        }
    }
}