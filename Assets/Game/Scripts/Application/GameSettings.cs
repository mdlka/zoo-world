using UnityEngine;

namespace ZooWorld
{
    [CreateAssetMenu(menuName = "ZooWorld/Settings/Create GameSettings", fileName = "GameSettings", order = 56)]
    public class GameSettings : ScriptableObject
    {
        [field: SerializeField, Min(0f)] public float MinSpawnDelay { get; private set; }
        [field: SerializeField, Min(0f)] public float MaxSpawnDelay { get; private set; }
    }
}