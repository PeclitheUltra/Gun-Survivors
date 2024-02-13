using System;
using Gameplay.Enemies.Attack;
using Gameplay.Enemies.Creation;
using Gameplay.Health;
using Gameplay.Movement;
using Gameplay.Player;
using Gameplay.UI.Displays;
using Sound;
using UnityEngine;
using VContainer;

namespace Gameplay.Enemies
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        public event Action<IEnemy> Death;
        private IHealth _health;
        private IMovement _movement;
        private IEnemySettings _settings;
        private IPlayerCharacter _player;
        private IEnemyAttacker _enemyAttacker;
        private ISFXPlayer _sfxPlayer;

        [Inject]
        private void Construct(IHealth health, IMovement movement, IPlayerCharacter player, IEnemyAttacker enemyAttacker, ISFXPlayer sfxPlayer)
        {
            _sfxPlayer = sfxPlayer;
            _enemyAttacker = enemyAttacker;
            _player = player;
            _movement = movement;
            _health = health;
        }

        private void Update()
        {
            var direction = _player.Position - transform.position;
            _movement.Move(transform, direction, _settings.MovementSpeed);
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
            
            _enemyAttacker.TryAttack(transform.position, _player, _settings);
        }


        public void DealDamage(float damage, Vector3 sourcePosition)
        {
            _health.DealDamage(damage);
            _sfxPlayer.PlayEnemyHit();
        }

        public void ApplySettings(IEnemySettings currentEnemy)
        {
            _settings = currentEnemy;
            Instantiate(currentEnemy.Graphics, transform.position, transform.rotation, transform);
            InitializeHealth();
        }

        private void InitializeHealth()
        {
            _health.SetMaxHealth(_settings.Health);
            _health.HealthBecameEmpty += HandleDeath;
            _health.HealthChanged += UpdateHealthDisplay;
        }

        private void UpdateHealthDisplay(float before, float after)
        {
            GetComponentInChildren<INormalizedDisplay>().SetValue(_health.CurrentHealth/_health.MaxHealth);
        }

        public void SetPosition(Vector3 characterPosition)
        {
            transform.position = characterPosition;
        }

        private void HandleDeath()
        {
            Death?.Invoke(this);
            _sfxPlayer.PlayEnemyDeath();
        }

        public void OnGetFromPool()
        {
            _health.RestoreHealthToFull();
            gameObject.SetActive(true);
        }

        public void OnReturnToPool()
        {
            gameObject.SetActive(false);
        }
    }
}