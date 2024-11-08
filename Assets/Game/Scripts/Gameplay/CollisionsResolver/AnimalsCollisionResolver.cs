namespace ZooWorld
{
    public class AnimalsCollisionResolver
    {
        private readonly ICollisionList _collisionList;
        
        public AnimalsCollisionResolver() : this(new CollisionSet()) { }

        public AnimalsCollisionResolver(ICollisionList collisionList)
        {
            _collisionList = collisionList;
        }
        
        public void AddCollision(Animal first, Animal second)
        {
            if (first is Prey firstPrey && second is Prey secondPrey)
                _collisionList.Add(new PreyCollision(firstPrey, secondPrey));
            else if (first is Predator firstPredators && second is Predator secondPredators)
                _collisionList.Add(new PredatorsCollision(firstPredators, secondPredators));
            else if (first is Predator predator && second is Prey prey)
                _collisionList.Add(new PredatorPreyCollision(predator, prey));
            else
                _collisionList.Add(new PredatorPreyCollision(second as Predator, first as Prey));
        }

        public void Resolve()
        {
            if (_collisionList.HasCollisions)
                _collisionList.HandleAll();
        }
    }
}