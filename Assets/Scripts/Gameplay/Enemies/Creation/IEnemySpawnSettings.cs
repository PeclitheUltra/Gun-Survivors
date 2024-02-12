using UnityEngine;

namespace Gameplay.Enemies.Creation
{
    public interface IEnemySpawnSettings
    {
        public Vector2 HorizontalBounds { get; }
        public Vector2 VerticalBounds { get; }
        public int MinimalEnemyOnScreenCount { get; }
        public float SpawnInterval { get; }
    }
}