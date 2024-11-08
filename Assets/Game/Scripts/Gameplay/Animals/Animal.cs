using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ZooWorld
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Animal : MonoBehaviour
    {
        private IMovement _movement;
        private AnimalsCollisionResolver _collisionResolver;
        private Vector3 _moveDirection;

        public event Action<Animal> Died;

        protected Rigidbody SelfRigidbody { get; private set; }

        public void Initialize(AnimalSettings settings, IMovement movement, AnimalsCollisionResolver collisionResolver)
        {
            if (_collisionResolver != null)
                throw new InvalidOperationException("Already initialized");

            SelfRigidbody = GetComponent<Rigidbody>();
            _movement = movement;
            _collisionResolver = collisionResolver;
            
            _moveDirection = Random.insideUnitCircle.normalized.FromXZ();

            OnInitialize(settings);
        }

        public void Dead()
        {
            Died?.Invoke(this);
            gameObject.SetActive(false);
        }

        private void FixedUpdate()
        {
            SelfRigidbody.MoveRotation(Quaternion.LookRotation(_moveDirection));
            _movement.ProcessMovement(_moveDirection, Time.deltaTime);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.TryGetComponent(out Animal otherAnimal))
                _collisionResolver.AddCollision(this, otherAnimal);
            else if (other.transform.TryGetComponent(out Border _))
                _moveDirection = Vector3.Reflect(_moveDirection, other.contacts[0].normal);
        }

        protected abstract void OnInitialize(AnimalSettings settings);
    }
}