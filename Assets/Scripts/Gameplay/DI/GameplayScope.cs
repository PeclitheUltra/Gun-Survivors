using Gameplay.Enemies;
using Gameplay.Enemies.Attack;
using Gameplay.Enemies.Creation;
using Gameplay.Enemies.Creation.CreationSettings;
using Gameplay.FX.PlayerShootFX;
using Gameplay.Health;
using Gameplay.Management;
using Gameplay.Movement;
using Gameplay.Player;
using Gameplay.Player.Input;
using Gameplay.Player.Shooting;
using Gameplay.Settings;
using Gameplay.Stats;
using Gameplay.UI;
using Gameplay.UI.Displays;
using Gameplay.UI.Screens;
using Sound;
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
        [SerializeField] private DoubleSliderWithDelay _playerHealthDisplay;
        [SerializeField] private FinishScreen _finishScreen;

        [SerializeField] private GunTrailFX _gunTrailFX;
        [SerializeField] private GunShootParticle _gunShootParticle;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameplayCoordinator>();

            var playerHealth = new Health.Health();
            RegisterPlayer(builder, playerHealth);
            builder.Register<EnemySpawner>(Lifetime.Scoped).As<IEnemySpawner>();
            builder.Register<EnemyFactory>(Lifetime.Scoped).As<IEnemyFactory>();
            builder.RegisterComponent<EnemyPool>(_enemyPool).As<IEnemyPool>();
            

            builder.RegisterComponentInNewPrefab<Enemy>(_enemyDummy, Lifetime.Transient).As<IEnemy>();
            builder.Register<EnemyAttacker>(Lifetime.Transient).As<IEnemyAttacker>();

            builder.Register<UICoordinator>(Lifetime.Scoped).As<IUICoordinator>().WithParameter<IHealth>(playerHealth).WithParameter<INormalizedDisplay>(_playerHealthDisplay);
            
            
            builder.Register<Health.Health>(Lifetime.Transient).As<IHealth>();
            
            //builder.Register<SimpleTransformMovement>(Lifetime.Transient).As<IMovement>();
            builder.Register<RigidbodyMovement>(Lifetime.Transient).As<IMovement>();

            builder.RegisterComponent<FinishScreen>(_finishScreen).As<IFinishScreen>();

            builder.RegisterComponent<GunTrailFX>(_gunTrailFX).As<IOnShootFX>();
            builder.RegisterComponent<GunShootParticle>(_gunShootParticle).As<IOnShootFX>();

            builder.RegisterComponentInHierarchy<ISFXPlayer>();
        }

        private void RegisterPlayer(IContainerBuilder builder, IHealth playerHealth)
        {
            builder.RegisterComponent<PlayerCharacter>(_playerCharacter).As<IPlayerCharacter>().WithParameter<IStats>(_playerSettings).WithParameter<IHealth>(playerHealth);
            builder.Register<KeyboardPlayerInput>(Lifetime.Scoped).As<IPlayerInput>();
            builder.Register<PlayerShooter>(Lifetime.Scoped).As<IPlayerShooter>().WithParameter<IStats>(_playerSettings).WithParameter<IPlayerAttackSettings>(_playerSettings);
        }
    }
}
