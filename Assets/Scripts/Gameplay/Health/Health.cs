using System;
using UnityEngine;

namespace Gameplay.Health
{
    public class Health : IHealth
    {
        public event Action HealthBecameEmpty;
        public event Action<float, float> HealthChanged;
        public float CurrentHealth => _currentHealth;
        public float MaxHealth => _maxHealth;
        private float _maxHealth;
        private float _currentHealth;

        public void DealDamage(float damage)
        {
            if (_currentHealth <= 0)
                return;
            
            float healthBefore = _currentHealth;
            _currentHealth -= damage;
            HealthChanged?.Invoke(healthBefore, _currentHealth);
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

        public void RestoreHealthToFull()
        {
            var healthBefore = _currentHealth;
            _currentHealth = _maxHealth;
            HealthChanged?.Invoke(healthBefore, _currentHealth);
        }

        private void Death()
        {
            HealthBecameEmpty?.Invoke();
        }
    }
}