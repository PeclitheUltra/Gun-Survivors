using System;
using Gameplay.Enemies.Creation;
using Gameplay.Pooling;
using UnityEngine;

namespace Gameplay.Enemies
{
    public interface IEnemy : IPoolable
    {
        public event Action<IEnemy> Death;
        public void DealDamage(float damage, Vector3 sourcePosition);
        public void ApplySettings(IEnemySettings currentEnemy);
        public void SetPosition(Vector3 characterPosition);
    }
}