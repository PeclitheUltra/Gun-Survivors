using Gameplay.Health;
using Gameplay.UI.Displays;
using VContainer;

namespace Gameplay.UI
{
    public class UICoordinator : IUICoordinator
    {
        private INormalizedDisplay _playerHealthDisplay;
        private IHealth _playerHealth;

        [Inject]
        private void Construct(INormalizedDisplay playerHealthDisplay, IHealth playerHealth)
        {
            _playerHealth = playerHealth;
            _playerHealthDisplay = playerHealthDisplay;
            playerHealth.HealthChanged += (_, _) =>
                _playerHealthDisplay.SetValue(_playerHealth.CurrentHealth / _playerHealth.MaxHealth);
        }
    }
}