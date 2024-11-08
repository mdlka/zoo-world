using System;
using Random = UnityEngine.Random;

namespace ZooWorld
{
    public class PredatorsCollision : BaseCollision
    {
        private readonly int _hashCode;
        private readonly Predator _first;
        private readonly Predator _second;
        
        public PredatorsCollision(Predator first, Predator second)
        {
            _first = first;
            _second = second;
            _hashCode = HashCode.Combine(_first, _second) + HashCode.Combine(_second, _first);
        }

        public override void Handle()
        {
            var winner = Random.value > 0.5f ? _first : _second;
            var loser = winner == _first ? _second : _first;
            
            loser.Dead();
            winner.ShowTasty();
        }

        public override int GetHashCode()
        {
            return _hashCode;
        }
    }
}