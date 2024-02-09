using System;
using Gameplay.Enemies.Creation;
using Gameplay.Health;
using Gameplay.Movement;
using Gameplay.Player;
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

        [Inject]
        private void Construct(IHealth health, IMovement movement, IPlayerCharacter player)
        {
            _player = player;
            _movement = movement;
            _health = health;
        }

        private void Update()
        {
            _movement.Move(transform, _player.Position - transform.position, _settings.MovementSpeed);
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
            Instantiate(currentEnemy.Graphics, transform.position, transform.rotation, transform);
        }

        private void Terminate()
        {
            _health.HealthBecameEmpty -= Terminate;
            Destroy(gameObject);
        }
    }
}