using Gameplay.Enemies;
using Gameplay.Enemies.Creation;
using Gameplay.Enemies.Creation.CreationSettings;
using Gameplay.Health;
using Gameplay.Management;
using Gameplay.Movement;
using Gameplay.Player;
using Gameplay.Player.Input;
using Gameplay.Player.Shooting;
using Gameplay.Settings;
using Gameplay.Stats;
using Gameplay.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Gameplay.DI
{
    public class GameplayScope : LifetimeScope
    {
        [SerializeField] private PlayerCharacter _playerCharacter;
        [SerializeField] private PlayerSettings _playerSettings;
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private Enemy _enemyDummy;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameplayCoordinator>();

            RegisterPlayer(builder);

            builder.Register<EnemySpawner>(Lifetime.Scoped).As<IEnemySpawner>();
            builder.Register<EnemyFactory>(Lifetime.Scoped).As<IEnemyFactory>();
            builder.RegisterComponent<EnemyPool>(_enemyPool).As<IEnemyPool>();

            builder.RegisterComponentInNewPrefab<Enemy>(_enemyDummy, Lifetime.Transient).As<IEnemy>();

            builder.Register<UICoordinator>(Lifetime.Scoped).As<IUICoordinator>();
            
            
            builder.Register<Health.Health>(Lifetime.Transient).As<IHealth>();
            builder.Register<SimpleTransformMovement>(Lifetime.Transient).As<IMovement>();
        }

        private void RegisterPlayer(IContainerBuilder builder)
        {
            builder.RegisterComponent<PlayerCharacter>(_playerCharacter).As<IPlayerCharacter>().WithParameter<IStats>(_playerSettings);
            builder.Register<KeyboardPlayerInput>(Lifetime.Scoped).As<IPlayerInput>();
            builder.Register<PlayerShooter>(Lifetime.Scoped).As<IPlayerShooter>().WithParameter<IStats>(_playerSettings).WithParameter<IPlayerAttackSettings>(_playerSettings);
        }
    }
}
