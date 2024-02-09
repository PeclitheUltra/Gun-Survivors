using System.Threading;
using Cysharp.Threading.Tasks;
using Gameplay.Player;

namespace Gameplay.Enemies.Creation
{
    public class EnemySpawner : IEnemySpawner
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
                _enemyFactory.GetEnemy();
                await UniTask.WaitForSeconds(interval, false, PlayerLoopTiming.Update, cancellationToken);
            }
        }
    }
}