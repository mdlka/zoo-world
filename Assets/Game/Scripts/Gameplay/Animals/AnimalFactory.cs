using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ZooWorld
{
    [CreateAssetMenu(menuName = "ZooWorld/Factories/Create AnimalFactory", fileName = "AnimalFactory", order = 56)]
    public class AnimalFactory : ScriptableObject, IFactory<Prey>, IFactory<Predator>
    {
        [SerializeField] private AnimalSettings _settings;
        [SerializeField] private PreyData[] _preysData;
        [SerializeField] private PredatorData[] _predatorsData;
        
        private AnimalsCollisionResolver _collisionResolver;
        private ISpawnZone _spawnZone;
        private Transform _container;
        
        public void Initialize(AnimalsCollisionResolver collisionResolver, ISpawnZone spawnZone, Transform container)
        {
            _collisionResolver = collisionResolver;
            _spawnZone = spawnZone;
            _container = container;
        }

        private T Create<T>(AnimalData<T> targetData) where T : Animal
        {
            var animalInstance = Instantiate(targetData.Template, _spawnZone.RandomPosition(), Quaternion.identity, _container);
            animalInstance.Initialize(_settings, targetData.MovementFactory.Create(animalInstance.GetComponent<Rigidbody>()), _collisionResolver);
            
            return animalInstance;
        }
        
        Prey IFactory<Prey>.Create() => Create(_preysData[Random.Range(0, _preysData.Length)]);
        Predator IFactory<Predator>.Create() => Create(_predatorsData[Random.Range(0, _predatorsData.Length)]);

        [Serializable]
        private class AnimalData<T> where T : Animal
        {
            [field: SerializeField] public T Template { get; private set; }
            [field: SerializeField] public MovementFactory MovementFactory { get; private set; }
        }

        [Serializable]
        private class PreyData : AnimalData<Prey> { }
        
        [Serializable]
        private class PredatorData : AnimalData<Predator> { }
    }
    
    [Serializable]
    public class AnimalSettings
    {
        [field: SerializeField, Min(0f)] public float PushForce { get; private set; }
        [field: SerializeField, Min(0f)] public float LabelShowDurationInSeconds { get; private set; }
    }
}