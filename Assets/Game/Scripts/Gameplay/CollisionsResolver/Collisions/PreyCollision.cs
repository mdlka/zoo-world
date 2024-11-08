using System;

namespace ZooWorld
{
    public class PreyCollision : BaseCollision
    {
        private readonly int _hashCode;
        private readonly Prey _first;
        private readonly Prey _second;
        
        public PreyCollision(Prey first, Prey second)
        {
            _first = first;
            _second = second;
            _hashCode = HashCode.Combine(_first, _second) + HashCode.Combine(_second, _first);
        }

        public override void Handle()
        {
            _first.Push((_first.Position - _second.Position).normalized);
            _second.Push((_second.Position - _first.Position).normalized);
        }

        public override int GetHashCode()
        {
            return _hashCode;
        }
    }
}