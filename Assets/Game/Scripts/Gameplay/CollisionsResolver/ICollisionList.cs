namespace ZooWorld
{
    public interface ICollisionList
    {
        bool HasCollisions { get; }
        
        void Add(ICollision collision);
        void HandleAll();
    }
}