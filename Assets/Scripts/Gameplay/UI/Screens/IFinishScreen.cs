using System;

namespace Gameplay.UI.Screens
{
    public interface IFinishScreen
    {
        public void Show(Action animationEndedCallback);
    }
}