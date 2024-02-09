using System;

namespace Gameplay.Health
{
    public interface IHealth
    {
        public event Action HealthBecameEmpty;
        public void DealDamage(float damage);
        public void SetMaxHealth(float health);

    }
}