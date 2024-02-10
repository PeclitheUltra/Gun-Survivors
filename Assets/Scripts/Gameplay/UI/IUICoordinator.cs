using System;

namespace Gameplay.UI
{
    public interface IUICoordinator
    {
        public void ShowFinishScreen(Action animationEndedCallback);
    }
}