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
                var enemy = _enemyFactory.GetEnemy();
                var targetPosition =
                    new Vector3(
                        Random.Range(_enemySpawnSettings.HorizontalBounds.x, _enemySpawnSettings.HorizontalBounds.y), 0,
                        Random.Range(_enemySpawnSettings.VerticalBounds.x, _enemySpawnSettings.VerticalBounds.y));
                enemy.SetPosition(targetPosition);
                await UniTask.WaitForSeconds(interval, false, PlayerLoopTiming.Update, cancellationToken);
            }
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