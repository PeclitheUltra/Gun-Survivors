using Gameplay.Enemies;
using Gameplay.Enemies.Creation;
using Gameplay.Player;
using Gameplay.UI;
using VContainer.Unity;

namespace Gameplay.Management
{
    public class GameplayCoordinator : IStartable
    {
        private IPlayerCharacter _playerCharacter;
        private IEnemySpawner _enemySpawner;
        private IUICoordinator _uiCoordinator;

        public GameplayCoordinator(IPlayerCharacter playerCharacter, IEnemySpawner enemySpawner,
            IUICoordinator uiCoordinator)
        {
            _uiCoordinator = uiCoordinator;
            _enemySpawner = enemySpawner;
            _playerCharacter = playerCharacter;
        }
        
        public void Start()
        {
            
        }
    }
}
