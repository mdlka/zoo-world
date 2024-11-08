using UnityEngine;

namespace ZooWorld
{
    public abstract class MovementFactory : ScriptableObject
    {
        public abstract IMovement Create(Rigidbody rigidbody);
    }
}