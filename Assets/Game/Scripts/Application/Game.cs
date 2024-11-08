using System.Collections;
using UnityEngine;

namespace ZooWorld
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameView _gameView;
        [SerializeField] private GameSettings _gameSettings;
        
        [Space, SerializeField] private AnimalFactory _animalFactory;
        [SerializeField] private SpawnZone _animalSpawnZone;
        [SerializeField] private Transform _animalsContainer;
        
        private AnimalsCollisionResolver _collisionResolver;

        private IEnumerator Start()
        {
            _collisionResolver = new AnimalsCollisionResolver();
            _animalFactory.Initialize(_collisionResolver, _animalSpawnZone, _animalsContainer);
            
            var animalPools = new AnimalPools(
                new ObjectPool<Prey>(_animalFactory, prewarm: 5),
                new ObjectPool<Predator>(_animalFactory, prewarm: 5));
            
            var session = new Session(_gameView, animalPools, _gameSettings);
            
            yield return session.Running();
        }
        
        private void FixedUpdate()
        {
            _collisionResolver.Resolve();
        }
    }
}
