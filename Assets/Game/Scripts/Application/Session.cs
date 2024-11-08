using System.Collections;
using UnityEngine;

namespace ZooWorld
{
    public class Session
    {
        private readonly IGameView _gameView;
        private readonly AnimalPools _animalPools;
        private readonly GameSettings _gameSettings;

        private int _deadPreys;
        private int _deadPredators;

        public Session(IGameView gameView, AnimalPools animalPools, GameSettings gameSettings)
        {
            _gameView = gameView;
            _animalPools = animalPools;
            _gameSettings = gameSettings;
        }

        public IEnumerator Running()
        {
            _gameView.Render(_deadPreys, _deadPredators);
            
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(_gameSettings.MinSpawnDelay, _gameSettings.MaxSpawnDelay));

                Animal animalInstance;

                if (Random.value > 0.5f)
                    animalInstance = _animalPools.PredatorsPool.Get();
                else
                    animalInstance = _animalPools.PreysPool.Get();

                animalInstance.Died += OnAnimalDied;
            }
        }

        private void OnAnimalDied(Animal animal)
        {
            animal.Died -= OnAnimalDied;

            if (animal is Prey prey)
            {
                _deadPreys += 1;
                _animalPools.PreysPool.Return(prey);
            }
            else if (animal is Predator predator)
            {
                _deadPredators += 1;
                _animalPools.PredatorsPool.Return(predator);
            }
            
            _gameView.Render(_deadPreys, _deadPredators);
        }
    }

    public record AnimalPools(IPool<Prey> PreysPool, IPool<Predator> PredatorsPool);
}