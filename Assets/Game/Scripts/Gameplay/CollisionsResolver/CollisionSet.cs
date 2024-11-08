using System.Collections.Generic;

namespace ZooWorld
{
    public class CollisionSet : ICollisionList
    {
        private readonly HashSet<ICollision> _collisions = new();

        public bool HasCollisions => _collisions.Count != 0;

        public void Add(ICollision collision)
        {
            _collisions.Add(collision);
        }

        public void HandleAll()
        {
            foreach (var collision in _collisions)
                collision.Handle();
            
            _collisions.Clear();
        }
    }
}