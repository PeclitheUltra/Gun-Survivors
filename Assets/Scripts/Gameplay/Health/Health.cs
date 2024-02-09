using System;
using UnityEngine;

namespace Gameplay.Health
{
    public class Health : IHealth
    {
        public event Action HealthBecameEmpty;
        private float _maxHealth;
        private float _currentHealth;

        public void DealDamage(float damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                Death();
            }
        }

        public void SetMaxHealth(float health)
        {
            _maxHealth = health;
            _currentHealth = _maxHealth;
        }

        private void Death()
        {
            HealthBecameEmpty?.Invoke();
        }
    }
}