using System;
using Gameplay.Health;
using Gameplay.Movement;
using Gameplay.Player.Input;
using Gameplay.Player.Shooting;
using Gameplay.Stats;
using UnityEngine;
using VContainer;

namespace Gameplay.Player
{
    public class PlayerCharacter : MonoBehaviour, IPlayerCharacter
    {
        public Vector3 Position => transform.position;
        public event Action Death;
        private IPlayerInput _input;
        private IMovement _movement;
        private IHealth _health;
        private IStats _playerStats;
        private IPlayerShooter _playerShooter;

        [Inject]
        private void Construct(IPlayerInput input, IMovement movement, IHealth health, IStats playerStats, IPlayerShooter playerShooter)
        {
            _playerShooter = playerShooter;
            _playerStats = playerStats;
            _health = health;
            _health.SetMaxHealth(_playerStats.Health);
            _health.HealthBecameEmpty += Die;
            _movement = movement;
            _input = input;
            playerShooter.ShotFired += RotateTowardsShot;
        }

        private void Die()
        {
            _health.HealthBecameEmpty -= Die;
            Death?.Invoke();
        }

        private void RotateTowardsShot(GameObject target)
        {
            var position = target.transform.position;
            position.y = transform.position.y;
            transform.LookAt(position);
        }


        public void DealDamage(float damage)
        {
            _health.DealDamage(damage);
        }

        private void Update()
        {
            ReadInputAndMove();
            _playerShooter.UpdateAndTryToShoot(transform.position);
        }

        private void ReadInputAndMove()
        {
            var input = _input.InputDirection;
            _movement.Move(transform, new Vector3(input.x, 0, input.y), _playerStats.MovementSpeed);
        }
    }
}