using System;

namespace Gameplay.Health
{
    public interface IHealth
    {
        public event Action HealthBecameEmpty;
        public event Action<float, float> HealthChanged;
        public float CurrentHealth { get; }
        public float MaxHealth { get; }
        public void DealDamage(float damage);
        public void SetMaxHealth(float health);
        public void RestoreHealthToFull();

    }
}