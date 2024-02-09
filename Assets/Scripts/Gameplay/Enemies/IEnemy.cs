using Gameplay.Enemies.Creation;
using UnityEngine;

namespace Gameplay.Enemies
{
    public interface IEnemy
    {
        public void DealDamage(float damage);
        public void ApplySettings(IEnemySettings currentEnemy);
        public void SetPosition(Vector3 characterPosition);
    }
}