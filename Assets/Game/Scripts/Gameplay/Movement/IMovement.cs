using UnityEngine;

namespace ZooWorld
{
    public interface IMovement
    {
        void ProcessMovement(Vector3 direction, float deltaTime);
    }
}