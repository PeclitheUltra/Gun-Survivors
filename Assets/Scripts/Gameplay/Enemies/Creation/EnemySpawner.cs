using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Gameplay.Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Enemies.Creation
{
    public class EnemySpawner : IEnemySpawner, IDisposable
    {
        private IPlayerCharacter _character;
        private IEnemyFactory _enemyFactory;
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private IEnemySpawnSettings _enemySpawnSettings;
        private int _enemiesSpawned;

        public EnemySpawner(IPlayerCharacter character, IEnemyFactory enemyFactory, IEnemySpawnSettings enemySpawnSettings)
        {
            _enemySpawnSettings = enemySpawnSettings;
            _enemyFactory = enemyFactory;
            _character = character;
        }

        public void StartSpawning()
        {
            SpawnContinuously(_enemySpawnSettings.SpawnInterval, _cancellationTokenSource.Token).Forget();
        }

        public void StopSpawning()
        {
            _cancellationTokenSource.Cancel();
        }

        private async UniTaskVoid SpawnContinuously(float interval, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                do SpawnEnemy();
                while (_enemiesSpawned < _enemySpawnSettings.MinimalEnemyOnScreenCount);

                await UniTask.WaitForSeconds(interval, false, PlayerLoopTiming.Update, cancellationToken);
            }
        }

        private void SpawnEnemy()
        {
            var enemy = _enemyFactory.GetEnemy();
            var targetPosition =
                new Vector3(
                    Random.Range(_enemySpawnSettings.HorizontalBounds.x, _enemySpawnSettings.HorizontalBounds.y), 0,
                    Random.Range(_enemySpawnSettings.VerticalBounds.x, _enemySpawnSettings.VerticalBounds.y));
            enemy.SetPosition(targetPosition);
            enemy.Death += HandleEnemyDeath;
            _enemiesSpawned++;
        }

        private void HandleEnemyDeath(IEnemy enemy)
        {
            _enemiesSpawned--;
            enemy.Death -= HandleEnemyDeath;
        }

        public void Dispose()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource?.Dispose();
        }

        public void Disable()
        {
            StopSpawning();
        }
    }
}