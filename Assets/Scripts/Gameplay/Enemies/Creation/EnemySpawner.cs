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

        public EnemySpawner(IPlayerCharacter character, IEnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
            _character = character;
        }

        public void StartSpawning(float interval)
        {
            SpawnContinuously(.5f, _cancellationTokenSource.Token).Forget();
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
                enemy.SetPosition(_character.Position + Vector3.right * 10 + Vector3.forward * (Random.value - .5f) * 10);
                await UniTask.WaitForSeconds(interval, false, PlayerLoopTiming.Update, cancellationToken);
            }
        }

        public void Dispose()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource?.Dispose();
        }
    }
}