using UnityEngine;

namespace ZooWorld
{
    public class ColliderSpawnZone : SpawnZone
    {
        [SerializeField] private float _positionY;
        [SerializeField] private Collider _collider;
        
        public override Vector3 RandomPosition()
        {
            return new Vector3(Random.Range(_collider.bounds.min.x, _collider.bounds.max.x), _positionY,
                Random.Range(_collider.bounds.min.z, _collider.bounds.max.z));
        }
    }
}