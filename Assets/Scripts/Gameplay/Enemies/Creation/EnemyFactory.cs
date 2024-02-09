using Gameplay.Enemies.Creation.CreationSettings;
using Gameplay.UI.Displays;
using Unity.VisualScripting;
using VContainer;

namespace Gameplay.Enemies.Creation
{
    public class EnemyFactory : IEnemyFactory
    {
        private IObjectResolver _resolver;
        private IEnemyPool _enemyPool;

        public EnemyFactory(IObjectResolver resolver, IEnemyPool enemyPool)
        {
            _enemyPool = enemyPool;
            _resolver = resolver;
        }
        
        public IEnemy GetEnemy()
        {
            var currentEnemy = _enemyPool.GetRandom();
            var enemy = _resolver.Resolve<IEnemy>();
            enemy.ApplySettings(currentEnemy);
            return enemy;
        }
    }
}
