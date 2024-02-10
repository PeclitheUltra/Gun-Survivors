using System;
using Gameplay.Enemies.Attack;
using Gameplay.Enemies.Creation;
using Gameplay.Health;
using Gameplay.Movement;
using Gameplay.Player;
using Gameplay.UI.Displays;
using UnityEngine;
using VContainer;

namespace Gameplay.Enemies
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        private IHealth _health;
        private IMovement _movement;
        private IEnemySettings _settings;
        private IPlayerCharacter _player;
        private IEnemyAttacker _enemyAttacker;

        [Inject]
        private void Construct(IHealth health, IMovement movement, IPlayerCharacter player, IEnemyAttacker enemyAttacker)
        {
            _enemyAttacker = enemyAttacker;
            _player = player;
            _movement = movement;
            _health = health;
        }

        private void Update()
        {
            _movement.Move(transform, _player.Position - transform.position, _settings.MovementSpeed);
            
            _enemyAttacker.TryAttack(transform.position, _player, _settings);
        }

        public void DealDamage(float damage)
        {
            _health.DealDamage(damage);
        }

        public void ApplySettings(IEnemySettings currentEnemy)
        {
            _settings = currentEnemy;
            _health.SetMaxHealth(_settings.Health);
            _health.HealthBecameEmpty += Terminate;
            _health.HealthChanged += UpdateHealthDisplay;
            Instantiate(currentEnemy.Graphics, transform.position, transform.rotation, transform);
        }

        private void UpdateHealthDisplay(float before, float after)
        {
            GetComponentInChildren<INormalizedDisplay>().SetValue(_health.CurrentHealth/_health.MaxHealth);
        }

        public void SetPosition(Vector3 characterPosition)
        {
            transform.position = characterPosition;
        }

        private void Terminate()
        {
            _health.HealthBecameEmpty -= Terminate;
            _health.HealthChanged -= UpdateHealthDisplay;
            Destroy(gameObject);
        }
    }
}