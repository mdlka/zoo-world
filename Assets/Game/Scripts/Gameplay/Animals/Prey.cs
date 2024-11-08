using UnityEngine;

namespace ZooWorld
{
    public sealed class Prey : Animal
    {
        private AnimalSettings _settings;
        
        public Vector3 Position => transform.position;
        
        protected override void OnInitialize(AnimalSettings settings)
        {
            _settings = settings;
        }
        
        public void Push(Vector3 direction)
        {
            SelfRigidbody.AddForce(direction * _settings.PushForce, ForceMode.VelocityChange);
        }
    }
}