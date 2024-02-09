namespace Gameplay.Enemies.Health
{
    public class EnemyHealth : IEnemyHealth
    {
        private float _maxHealth;
        private float _currentHealth;

        public void SetMaxHealth(float health)
        {
            _maxHealth = health;
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