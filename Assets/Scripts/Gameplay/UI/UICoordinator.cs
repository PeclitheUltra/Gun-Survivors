using System;
using Gameplay.Health;
using Gameplay.UI.Displays;
using Gameplay.UI.Screens;
using VContainer;

namespace Gameplay.UI
{
    public class UICoordinator : IUICoordinator
    {
        private INormalizedDisplay _playerHealthDisplay;
        private IHealth _playerHealth;
        private IFinishScreen _finishScreen;

        [Inject]
        private void Construct(INormalizedDisplay playerHealthDisplay, IHealth playerHealth, IFinishScreen finishScreen)
        {
            _finishScreen = finishScreen;
            _playerHealth = playerHealth;
            _playerHealthDisplay = playerHealthDisplay;
            playerHealth.HealthChanged += (_, _) =>
                _playerHealthDisplay.SetValue(_playerHealth.CurrentHealth / _playerHealth.MaxHealth);
        }

        public void ShowFinishScreen(Action animationEndedCallback)
        {
            _finishScreen.Show(animationEndedCallback);
        }
    }
}