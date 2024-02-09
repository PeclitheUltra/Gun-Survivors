using System;
using Gameplay.Enemies.Creation;
using Gameplay.Enemies.Health;
using Gameplay.Movement;
using Gameplay.Player;
using UnityEngine;
using VContainer;

namespace Gameplay.Enemies
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        private IEnemyHealth _health;
        private IMovement _movement;
        private IEnemySettings _currentEnemy;
        private IPlayerCharacter _player;

        [Inject]
        private void Construct(IEnemyHealth health, IMovement movement, IPlayerCharacter player)
        {
            _player = player;
            _movement = movement;
            _health = health;
        }

        private void Update()
        {
            _movement.Move(transform, _player.Position - transform.position);
        }

        public void DealDamage(float damage)
        {
            _health.DealDamage(damage);
        }

        public void ApplySettings(IEnemySettings currentEnemy)
        {
            _currentEnemy = currentEnemy;
            Instantiate(currentEnemy.Graphics, transform.position, transform.rotation, transform);
        }
    }
}