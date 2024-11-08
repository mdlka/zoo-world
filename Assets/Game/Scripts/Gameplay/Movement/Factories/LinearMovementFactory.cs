using UnityEngine;

namespace ZooWorld
{
    [CreateAssetMenu(menuName = "ZooWorld/Factories/Movement/Create LinearMovementFactory", fileName = "LinearMovementFactory", order = 56)]
    public class LinearMovementFactory : MovementFactory
    {
        [SerializeField, Min(0f)] private float _moveSpeed;
        
        public override IMovement Create(Rigidbody rigidbody)
        {
            return new LinearMovement(rigidbody, _moveSpeed);
        }
    }
}