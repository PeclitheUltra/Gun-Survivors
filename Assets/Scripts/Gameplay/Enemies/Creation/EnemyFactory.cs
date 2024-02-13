using System.Collections.Generic;
using Gameplay.Enemies.Creation.CreationSettings;
using VContainer;

namespace Gameplay.Enemies.Creation
{
    public class EnemyFactory : IEnemyFactory
    {
        private IObjectResolver _resolver;
        private IEnemyPool _enemyPool;
        private Queue<IEnemy> _enemyReuseQueue;

        public EnemyFactory(IObjectResolver resolver, IEnemyPool enemyPool)
        {
            _enemyPool = enemyPool;
            _resolver = resolver;
            _enemyReuseQueue = new Queue<IEnemy>();
        }
        
        public IEnemy GetEnemy()
        {
            if (_enemyReuseQueue.Count > 0)
            {
                var enemy = _enemyReuseQueue.Peek();
                _enemyReuseQueue.Dequeue();
                enemy.OnGetFromPool();
                return enemy;
            }
            else
            {
                return CreateNewEnemy();
            }
        }

        private IEnemy CreateNewEnemy()
        {
            var currentEnemy = _enemyPool.GetRandom();
            var enemy = _resolver.Resolve<IEnemy>();
            enemy.ApplySettings(currentEnemy);
            enemy.Death += PutIntoQueue;
            return enemy;
        }

        public void PutIntoQueue(IEnemy enemy)
        {
            _enemyReuseQueue.Enqueue(enemy);
            enemy.OnReturnToPool();
        }
    }
}
