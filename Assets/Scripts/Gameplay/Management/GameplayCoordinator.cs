using System;
using Gameplay.Enemies;
using Gameplay.Enemies.Creation;
using Gameplay.Player;
using Gameplay.UI;
using UnityEngine.SceneManagement;
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
            _enemySpawner.StartSpawning(.5f);
            _playerCharacter.Death += HandlePlayerDeath;
        }

        private void HandlePlayerDeath()
        {
            _uiCoordinator.ShowFinishScreen(RestartGame);
        }

        private void RestartGame()
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(1);
        }
    }
}
