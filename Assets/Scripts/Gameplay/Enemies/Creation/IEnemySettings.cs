using UnityEngine;

namespace Gameplay.Enemies.Creation
{
    public interface IEnemySettings
    {
        public GameObject Graphics { get; }
        public float Health { get; }
        public float MovementSpeed { get; }
        public float AttackDamage { get; }
        public float RecoveryTime { get; }
    }
}
