using System;

namespace ZooWorld
{
    public class PredatorPreyCollision : BaseCollision
    {
        private readonly int _hashCode;
        private readonly Predator _predator;
        private readonly Prey _prey;

        public PredatorPreyCollision(Predator predator, Prey prey)
        {
            _prey = prey;
            _predator = predator;
            _hashCode = HashCode.Combine(_prey, _predator);
        }

        public override void Handle()
        {
            _prey.Dead();
            _predator.ShowTasty();
        }

        public override int GetHashCode()
        {
            return _hashCode;
        }
    }
}