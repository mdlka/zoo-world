using System;

namespace ZooWorld
{
    public abstract class BaseCollision : ICollision
    {
        public bool Equals(ICollision other)
        {
            return other.GetHashCode() == GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is not null && Equals((BaseCollision)obj);
        }
        
        public abstract void Handle();
        public abstract override int GetHashCode();
    }
}