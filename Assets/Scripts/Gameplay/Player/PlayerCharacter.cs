using System;
using System.Collections.Generic;
using Gameplay.FX.PlayerShootFX;
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
        [SerializeField] private Transform _shootPoint;
        public Vector3 Position => transform.position;
        public event Action Death;
        private IPlayerInput _input;
        private IMovement _movement;
        private IHealth _health;
        private IStats _playerStats;
        private IPlayerShooter _playerShooter;
        private IEnumerable<IOnShootFX> _onShootFx;

        [Inject]
        private void Construct(IPlayerInput input, IMovement movement, IHealth health, IStats playerStats, IPlayerShooter playerShooter, IEnumerable<IOnShootFX> onShootFx)
        {
            _onShootFx = onShootFx;
            _playerShooter = playerShooter;
            _playerStats = playerStats;
            _health = health;
            _health.SetMaxHealth(_playerStats.Health);
            _health.HealthBecameEmpty += Die;
            _movement = movement;
            _input = input;
            playerShooter.ShotFired += HandleShotFired;
        }

        private void Die()
        {
            _health.HealthBecameEmpty -= Die;
            Death?.Invoke();
        }

        private void HandleShotFired(GameObject target)
        {
            var position = target.transform.position;
            position.y = transform.position.y;
            transform.LookAt(position);
            foreach (var fx in _onShootFx)
            {
                var startPosition = _shootPoint.position;
                var endPosition = target.transform.position;
                endPosition.y = startPosition.y;
                fx.PlayOnShoot(startPosition, endPosition);
            }
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