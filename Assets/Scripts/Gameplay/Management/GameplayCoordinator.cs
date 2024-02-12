using System;
using System.Collections.Generic;
using Gameplay.Enemies;
using Gameplay.Enemies.Creation;
using Gameplay.Player;
using Gameplay.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
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
            _enemySpawner.StartSpawning();
            _playerCharacter.Death += HandlePlayerDeath;
        }

        private void HandlePlayerDeath()
        {
            Time.timeScale = 0;
            _uiCoordinator.ShowFinishScreen(RestartGame);
        }

        private void RestartGame()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
