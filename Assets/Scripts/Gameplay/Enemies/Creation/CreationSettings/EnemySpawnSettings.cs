using UnityEngine;

namespace Gameplay.Enemies.Creation.CreationSettings
{
    [CreateAssetMenu]
    public class EnemySpawnSettings : ScriptableObject, IEnemySpawnSettings
    {
        [field:SerializeField] public Vector2 HorizontalBounds { get; private set; }
        [field:SerializeField] public Vector2 VerticalBounds { get; private set; }
        [field:SerializeField] public int MinimalEnemyOnScreenCount { get; private set; }
        [field:SerializeField] public float SpawnInterval { get; private set; }
    }
}