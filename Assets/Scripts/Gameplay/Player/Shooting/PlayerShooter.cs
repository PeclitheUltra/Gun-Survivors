using System;
using System.Collections.Generic;
using Gameplay.Enemies;
using Gameplay.FX.PlayerShootFX;
using Gameplay.Settings;
using Gameplay.Stats;
using UnityEngine;

namespace Gameplay.Player.Shooting
{
    public class PlayerShooter : IPlayerShooter
    {
        public event Action<GameObject> ShotFired;
        private IStats _playerStats;
        private IPlayerAttackSettings _playerAttackSettings;
        private float _lastTimeAttacked;
        private Collider[] _colliders = new Collider[10];
        private IEnumerator<IOnShootFX> _shootFx;

        public PlayerShooter(IStats playerStats, IPlayerAttackSettings playerAttackSettings)
        {
            _playerAttackSettings = playerAttackSettings;
            _playerStats = playerStats;
        }

        public void UpdateAndTryToShoot(Vector3 checkOrigin)
        {
            if (Time.time > _lastTimeAttacked + _playerStats.AttackTime)
            {
                TryToShoot(checkOrigin);
                _lastTimeAttacked = Time.time;
            }
        }
        
        private void TryToShoot(Vector3 checkOrigin)
        {
            var hits = Physics.OverlapSphereNonAlloc(checkOrigin, _playerStats.AttackRange, _colliders,
                _playerAttackSettings.AttackMask);
            if (hits == 0)
                return;
            float minDistanceSquared = Mathf.Infinity;
            int minId = 0;
            for (int i = 0; i < hits; i++)
            {
                var distanceSquared = Vector3.SqrMagnitude(checkOrigin - _colliders[i].transform.position);
                if (distanceSquared < minDistanceSquared)
                {
                    minDistanceSquared = distanceSquared;
                    minId = i;
                }
            }

            Shoot(_colliders[minId].gameObject);
        }

        private void Shoot(GameObject gameObject)
        {
            if (gameObject.TryGetComponent<IEnemy>(out var enemy))
            {
                enemy.DealDamage(_playerStats.AttackDamage);
                ShotFired?.Invoke(gameObject);
            }
        }
    }
}