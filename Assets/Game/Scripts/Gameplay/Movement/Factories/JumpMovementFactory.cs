using UnityEngine;

namespace ZooWorld
{
    [CreateAssetMenu(menuName = "ZooWorld/Factories/Movement/Create JumpMovementFactory", fileName = "JumpMovementFactory", order = 56)]
    public class JumpMovementFactory : MovementFactory
    {
        [SerializeField, Min(0f)] private float _delay;
        [SerializeField, Min(0f)] private float _verticalForce;
        [SerializeField, Min(0f)] private float _horizontalForce;

        public override IMovement Create(Rigidbody rigidbody)
        {
            return new JumpMovement(rigidbody, new JumpMovement.Args(_delay, _verticalForce, _horizontalForce));
        }
    }
}