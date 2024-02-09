using Gameplay.Enemies.Creation;

namespace Gameplay.Enemies
{
    public interface IEnemy
    {
        public void DealDamage(float damage);
        public void ApplySettings(IEnemySettings currentEnemy);
    }
}