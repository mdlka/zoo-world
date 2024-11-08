using UnityEngine;

namespace ZooWorld
{
    public class JumpMovement : IMovement
    {
        private readonly Rigidbody _rigidbody;
        private readonly Args _args;

        private float _elapsedTime;

        public JumpMovement(Rigidbody rigidbody, Args args)
        {
            _rigidbody = rigidbody;
            _args = args;
        }
        
        public void ProcessMovement(Vector3 direction, float deltaTime)
        {
            _elapsedTime += deltaTime;

            if (_elapsedTime < _args.Delay)
                return;

            _rigidbody.AddForce(direction * _args.HorizontalForce + Vector3.up * _args.VerticalForce, ForceMode.VelocityChange);
            _elapsedTime = 0f;
        }

        public record Args(float Delay, float VerticalForce, float HorizontalForce);
    }
}