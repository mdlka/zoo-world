using System;

namespace ZooWorld
{
    public interface ICollision : IEquatable<ICollision>
    {
        void Handle();
    }
}