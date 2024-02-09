using Gameplay.Settings;
using Gameplay.Stats;

namespace Gameplay.Player.Health
{
    public class PlayerHealth : IPlayerHealth
    {
        private float _maxHealth;
        private float _currentHealth;

        public PlayerHealth(IStats stats)
        {
            _maxHealth = stats.Health;
            _currentHealth = _maxHealth;
        }

        public void DealDamage(float damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                Death();
            }
        }

        private void Death()
        {
            throw new System.NotImplementedException();
        }
    }
}