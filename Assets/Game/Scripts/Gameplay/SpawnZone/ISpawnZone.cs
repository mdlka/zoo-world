using UnityEngine;

namespace ZooWorld
{
    public interface ISpawnZone
    {
        Vector3 RandomPosition();
    }

    public abstract class SpawnZone : MonoBehaviour, ISpawnZone
    {
        public abstract Vector3 RandomPosition();
    }
}