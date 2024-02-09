using Gameplay.Management;
using Gameplay.Movement;
using Gameplay.Player;
using Gameplay.Player.Health;
using Gameplay.Player.Input;
using Gameplay.Player.Shooting;
using Gameplay.Settings;
using Gameplay.Stats;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Gameplay.DI
{
    public class GameplayScope : LifetimeScope
    {
        [SerializeField] private PlayerCharacter _playerCharacter;
        [SerializeField] private PlayerSettings _playerSettings;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameplayCoordinator>();

            RegisterPlayer(builder);
            
            
        }

        private void RegisterPlayer(IContainerBuilder builder)
        {
            var playerMovement = new SimpleTransformMovement(_playerSettings);
            builder.RegisterComponent<PlayerCharacter>(_playerCharacter).As<IPlayerCharacter>().WithParameter<IMovement>(playerMovement);
            builder.Register<KeyboardPlayerInput>(Lifetime.Scoped).As<IPlayerInput>();
            builder.Register<PlayerShooter>(Lifetime.Scoped).As<IPlayerShooter>();
            builder.Register<PlayerHealth>(Lifetime.Scoped).As<IPlayerHealth>().WithParameter<IStats>(_playerSettings);
        }
    }
}
